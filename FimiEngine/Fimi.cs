using System.Data.SqlClient;
using System.Diagnostics;
using System.ServiceProcess;
using Dapper;
using FimiEngine.HelpingClasses;
using NLog;
using SqlKata.Compilers;
using SqlKata.Execution;

namespace FimiEngine;

public static class Fimi
{
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    private static QueryFactory db;

    public static IEnumerable<FimiTransaction> SearchTransaction(FimiSearchClass options, string connection)
    {
        var res = new List<FimiTransaction>();
        using (var conn = new SqlConnection(connection))
        {
            try
            {
                db = new QueryFactory(conn, new SqlServerCompiler());
                //get trsx from db by date
                res = FilterByDate(options.fromDate, options.toDate);
                //filter for success trsx
                res = FilterByStatus(options.response, res);
                //check for account
                res = FilterByAccount(options.Account, res);
                //check for account
                res = FilterByReference(options.Reference, res);
                //check for type
                res = FilterByType(options.type, res);
                //check for TransactionID
                res = FilterByTransactionId(options.TransactionID, res);
                res = FilterByTransactionAmount(options.Amount, res);
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, "SearchTransactionError:" + e.Message);
            }
        }

        return res;
    }

    public static bool RetryFailedTransaction(FimiTransaction data, string connection)
    {
        if (data.response_Desc.Contains("Approved")) return false;
        using (var conn = new SqlConnection(connection))
        {
            try
            {
                db = new QueryFactory(conn, new SqlServerCompiler());
                db.Query("Transaction_Log")
                    .Where("id", data.id)
                    .AsUpdate(new {Date = DateTime.Now, response = 0})
                    .Get<int>();
                return true;
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, "RetryFailedTransactionError:" + e.Message);
            }
        }

        return false;
    }

    public static string CheckFimiServiceStatus(string ServiceName, string MachineName, string OS)
    {
        try
        {
            switch (OS)
            {
                case "Linux":
                    var proc = System.Diagnostics.Process.GetProcessesByName(ServiceName, MachineName);
                    return proc.Length > 0 ? "Running" : "Stopped";
                    break;
                case "Windows":
                    var sc = new ServiceController(ServiceName, MachineName);
                    return sc.Status.ToString();
            }
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Error, "CheckFimiServiceStatusError:" + e.Message);
        }

        return "System Error";
    }

    public static string StartFimiService(string ServiceName, string MachineName, string OS)
    {
        try
        {
            switch (OS)
            {
                case "Linux":
                    var proc = System.Diagnostics.Process.GetProcessesByName(ServiceName, MachineName);
                    Process.Start(ServiceName, MachineName);
                    return proc.Length > 0 ? "Running" : "Stopped";
                    break;
                case "Windows":
                    var sc = new ServiceController(ServiceName, MachineName);
                    sc.Start();
                    return sc.Status.ToString();
            }
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Error, "CheckFimiServiceStatusError:" + e.Message);
        }

        return "System Error";
    }

    public static string StopFimiService(string ServiceName, string MachineName, string OS)
    {
        try
        {
            switch (OS)
            {
                case "Linux":
                    var proc = System.Diagnostics.Process.GetProcessesByName(ServiceName, MachineName);
                    proc[0].Kill();
                    return proc.Length > 0 ? "Running" : "Stopped";
                    break;
                case "Windows":
                    var sc = new ServiceController(ServiceName, MachineName);
                    sc.Stop();
                    return sc.Status.ToString();
            }
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Error, "CheckFimiServiceStatusError:" + e.Message);
        }

        return "System Error";
    }

    #region private methods

    private static List<FimiTransaction> FilterByDate(DateTime fromDate, DateTime toDate)
    {
        return db.Query("Transaction_Log")
            .WhereBetween("Date", fromDate, toDate)
            .Get<FimiTransaction>().AsList();
    }

    private static List<FimiTransaction> FilterByStatus(int status, List<FimiTransaction> data)
    {
        return status > 0 ? data.Where(trsx => trsx.response == status).ToList() : data;
    }

    private static List<FimiTransaction> FilterByAccount(string account, List<FimiTransaction> data)
    {
        return !string.IsNullOrEmpty(account) ? data.Where(trsx => trsx.Account == account).ToList() : data;
    }

    private static List<FimiTransaction> FilterByReference(string reff, List<FimiTransaction> data)
    {
        return !string.IsNullOrEmpty(reff) ? data.Where(trsx => trsx.Account == reff).ToList() : data;
    }

    private static List<FimiTransaction> FilterByType(string _type, List<FimiTransaction> data)
    {
        return !string.IsNullOrEmpty(_type) ? data.Where(trsx => trsx.type == _type).ToList() : data;
    }

    private static List<FimiTransaction> FilterByTransactionId(string tid, List<FimiTransaction> data)
    {
        return !string.IsNullOrEmpty(tid) ? data.Where(trsx => trsx.TransactionID == tid).ToList() : data;
    }

    private static List<FimiTransaction> FilterByTransactionAmount(decimal amount, List<FimiTransaction> data)
    {
        return amount != 0 ? data.Where(trsx => trsx.Amount == amount).ToList() : data;
    }

    #endregion
}