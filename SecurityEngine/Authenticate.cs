using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using NLog;
using SecurityEngine.HelpingClasses;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace SecurityEngine;

public static class Authenticate
{
    private static List<UserModel> userInfoDb;
    private static DataTable userInfoDataTable;
    private static NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

    public static void Init()
    {
        userInfoDb = new List<UserModel>();
    }

    public static string AuthenticateUser(UserModel userInfo)
    {
        _logger.Log(LogLevel.Info, "AuthenticateUser_Request...Payload:" + userInfo);
        var user = Login(userInfo);
        return !user.Active ? GenerateAuthToken(user) : string.Empty;
    }

    private static string GenerateHash(UserModel userInfo)
    {
        // Uses SHA256 to create the hash
        using (var sha = new System.Security.Cryptography.SHA256Managed())
        {
            // Convert the string to a byte array first, to be processed
            var textBytes =
                System.Text.Encoding.UTF8.GetBytes(userInfo.Username + "_" + userInfo.Password + "_z3nith_webDMZ_01");
            var hashBytes = sha.ComputeHash(textBytes);

            // Convert back to a string, removing the '-' that BitConverter adds
            var hash = BitConverter
                .ToString(hashBytes)
                .Replace("-", String.Empty);

            return hash;
        }
    }

    private static UserModel Login(UserModel userInfo)
    {
        userInfoDb ??= new List<UserModel>();
        var hash = GenerateHash(userInfo);
        var dd = new UserModel();
        try
        {
            dd = userInfoDb.FirstOrDefault(user => user.Password == hash);
            if (dd != null) return dd;
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Error, "LoginError: user not in memcache.");
        }

        userInfo.Password = hash;
        dd = GetUserFromDb(userInfo);
        userInfoDb.Add(dd);

        return dd;
    }

    private static UserModel GetUserFromDb(UserModel userInfo)
    {
        return Db.GetUser(new AuthModel()
        {
            Password = userInfo.Password
        });
    }

    private static string GenerateAuthToken(UserModel userInfo)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("This_is_the_best_secret_key_MyJwtP@$$w0rd"));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var uRoles = Db.GetuserRoles(userInfo);
        var uApps = Db.GetUserApps(userInfo.Uid);
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userInfo.Username),
            new Claim(JwtRegisteredClaimNames.Email, userInfo.EmailAddress),
            new Claim("CreateDate", userInfo.CreateDate.ToString("yyyy-MM-dd")),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim("ApplicationList", JsonConvert.SerializeObject(Db.GetUserApps(userInfo.Uid)))
        };
        if (uRoles.Reports)
        {
            claims = claims.Append(new Claim("Reports", Convert.ToString(uRoles.Reports))).ToArray();
        }

        if (uRoles.Super)
        {
            claims = claims.Append(new Claim("Super", Convert.ToString(uRoles.Super))).ToArray();
        }

        if (uRoles.Setup)
        {
            claims = claims.Append(new Claim("Setup", Convert.ToString(uRoles.Setup))).ToArray();
        }

        if (uRoles.Modify)
        {
            claims = claims.Append(new Claim("Modify", Convert.ToString(uRoles.Modify))).ToArray();
        }

        if (uRoles.Service)
        {
            claims = claims.Append(new Claim("Service", Convert.ToString(uRoles.Service))).ToArray();
        }

        if (uRoles.CreateUser)
        {
            claims = claims.Append(new Claim("CreateUser", Convert.ToString(uRoles.CreateUser))).ToArray();
        }

        if (uApps.Has_Cib)
        {
            claims = claims.Append(new Claim("CibUser", Convert.ToString(uApps.Has_Cib))).ToArray();
        }

        if (uApps.Has_Fimi)
        {
            claims = claims.Append(new Claim("FimiUser", Convert.ToString(uApps.Has_Fimi))).ToArray();
        }

        if (uApps.Has_Globalpay)
        {
            claims = claims.Append(new Claim("GlobalpayUser", Convert.ToString(uApps.Has_Globalpay))).ToArray();
        }

        if (uApps.Has_Zprompt)
        {
            claims = claims.Append(new Claim("ZpromptUser", Convert.ToString(uApps.Has_Zprompt))).ToArray();
        }

        if (uApps.Has_DirectDebit)
        {
            claims = claims.Append(new Claim("DirectDebitUser", Convert.ToString(uApps.Has_DirectDebit))).ToArray();
        }

        if (uApps.Has_Iteller)
        {
            claims = claims.Append(new Claim("ItellerUser", Convert.ToString(uApps.Has_Iteller))).ToArray();
        }

        if (uApps.Has_CsuMessenger)
        {
            claims = claims.Append(new Claim("CsumessengerUser", Convert.ToString(uApps.Has_CsuMessenger))).ToArray();
        }

        if (uApps.Has_Ussd)
        {
            claims = claims.Append(new Claim("UssdUser", Convert.ToString(uApps.Has_Ussd))).ToArray();
        }

        if (uApps.Has_ThirdpartyMails)
        {
            claims = claims.Append(new Claim("ThirdpartyUser", Convert.ToString(uApps.Has_ThirdpartyMails))).ToArray();
        }

        var token = new JwtSecurityToken("epcore.com",
            "epcore.com",
            claims,
            expires: DateTime.Now.AddMinutes(120),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}