using System.Data.SqlClient;
using SqlKata.Compilers;
using SqlKata.Execution;
using LogLevel = NLog.LogLevel;

namespace FastpaceProcessor.HelpingClasses;

public static class DatabaseEngine
{
    static IConfigurationRoot _configuration;
    static SqlServerCompiler dbCompiler;
    private static QueryFactory _queryFactory;
    private static NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

    static DatabaseEngine()
    {
        _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
    }

    public static Decimal GetAccountBalance(string userId)
    {
        using (var conn = new SqlConnection(_configuration["SecurityEngineSettings:EPCoreSqlDbConnection"]))
        {
            try
            {
                _queryFactory = new QueryFactory(conn, new SqlServerCompiler());
                var res = _queryFactory.Query("CompanyAccounts")
                    .Where("compid", userId).Get<CompanyAccounts>()
                    .FirstOrDefault()!.Balance;
                return res;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, "CreateUser_Error >>>> " + ex.Message);
            }
        }

        return (decimal) 0.00;
    }

    public static float GetCurrencyRate(int cid)
    {
        using (var conn = new SqlConnection(_configuration["SecurityEngineSettings:EPCoreSqlDbConnection"]))
        {
            try
            {
                _queryFactory = new QueryFactory(conn, new SqlServerCompiler());
                var res = _queryFactory.Query("Currencies")
                    .Where("cid", cid).Get<float>()
                    .FirstOrDefault();
                return res;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, "CreateUser_Error >>>> " + ex.Message);
            }
        }

        return (float) 0.00;
    }

    public static PaymentInformation GeAccountInfo(AccountInfoClass data)
    {
        var res = new PaymentInformation();
        res.paymentInformation = new List<Responseobject>();
        using (var conn = new SqlConnection(_configuration["SecurityEngineSettings:EPCoreSqlDbConnection"]))
        {
            try
            {
                _queryFactory = new QueryFactory(conn, new SqlServerCompiler());
                res.paymentInformation.AddRange(_queryFactory.Query("BankAccounts")
                    .Where("aid", data.accountNumber).Get<Responseobject>()
                    .ToList());
                return res;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, "GeAccountInfoError >>>> " + ex.Message);
            }
        }

        return new PaymentInformation();
    }
}