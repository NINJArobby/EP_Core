using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using NLog;
using SecurityEngine.HelpingClasses;
using SqlKata;
using SqlKata.Compilers;
using SqlKata.Execution;


namespace SecurityEngine;

public static class Db
{
    static IConfigurationRoot _configuration;
    static SqlServerCompiler dbCompiler;
    private static QueryFactory _queryFactory;
    private static NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

    static Db()
    {
        _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
    }

    public static UserApps GetUserApps(int userId)
    {
        using (var conn = new SqlConnection(_configuration["SecurityEngineSettings:EPCoreSqlDbConnection"]))
        {
            try
            {
                _queryFactory = new QueryFactory(conn, new SqlServerCompiler());
                var res = _queryFactory.Query("UsersAppsTable").Where("uid", userId).Get<UserApps>()
                    .FirstOrDefault();
                return res;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, "CreateUser_Error >>>> " + ex.Message);
            }
        }

        return null;
    }

    public static bool CreateUser(AuthModel userInfo)
    {
        using (var conn = new SqlConnection(_configuration["SecurityEngineSettings:EPCoreSqlDbConnection"]))
        {
            try
            {
                _queryFactory = new QueryFactory(conn, new SqlServerCompiler());
                var res = _queryFactory.Query("UsersTable").InsertGetId<int>(userInfo);
                if (res > 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, "CreateUser_Error >>>> " + ex.Message);
            }
        }

        return false;
    }

    public static UserModel GetUser(AuthModel userInfo)
    {
        using (var conn = new SqlConnection(_configuration["SecurityEngineSettings:EPCoreSqlDbConnection"]))
        {
            try
            {
                _queryFactory = new QueryFactory(conn, new SqlServerCompiler());
                var res = _queryFactory.Query("UsersTable").Where("Password", userInfo.Password).Get<UserModel>()
                    .FirstOrDefault();
                return res;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, "CreateUser_Error >>>> " + ex.Message);
            }
        }

        return null;
    }

    public static UserRoles GetuserRoles(UserModel userInfo)
    {
        using (var conn = new SqlConnection(_configuration["SecurityEngineSettings:EPCoreSqlDbConnection"]))
        {
            try
            {
                _queryFactory = new QueryFactory(conn, new SqlServerCompiler());
                return _queryFactory.Query("UserRoleTable").Where("Uid", userInfo.Uid).Get<UserRoles>()
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, "GetuserRoles_Error >>>> " + ex.Message);
            }
        }

        return null;
    }
}