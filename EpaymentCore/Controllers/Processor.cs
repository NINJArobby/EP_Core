using EpaymentCore.HelpingClasses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SecurityEngine.HelpingClasses;
using LogLevel = NLog.LogLevel;

namespace EpaymentCore.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class Processor : ControllerBase
{
    private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

    [HttpPost("CreateUser")]
    [Authorize]
    public ResponseObject CreateUser(SecurityEngine.AuthModel data)
    {
        _logger.Log(LogLevel.Info, "Setup request recieved. Payload:" + JsonConvert.SerializeObject(data));
        var currentUser = HttpContext.User;
        if (!currentUser.HasClaim(c => c.Type == "Super") || !currentUser.HasClaim(c => c.Type == "CreateUser"))
        {
            _logger.Log(LogLevel.Error,
                "Unauthorised Action:Setup request recieved. Payload:" + JsonConvert.SerializeObject(data) +
                ", user is:" + currentUser);
            return new ResponseObject()
            {
                code = "03",
                message = "Unauthorized Action",
                status = false
            };
        }

        data.CreateDate = DateTime.Now;
        if (SecurityEngine.Db.CreateUser(data))
        {
            _logger.Log(LogLevel.Info, "user created succesfully. user is:" + currentUser);
            return new ResponseObject()
            {
                code = "00",
                message = "User created successfully",
                status = true
            };
        }

        _logger.Log(LogLevel.Info, "add user failed. user is:" + currentUser);
        return new ResponseObject()
        {
            code = "01",
            message = "User creation failed",
            status = false
        };
    }

    [HttpPost("Login")]
    [AllowAnonymous]
    public ResponseObject Login(UserModel data)
    {
        var res = SecurityEngine.Authenticate.AuthenticateUser(data);
        //HttpContext.Session.SetString("EpCoreSession",res);
        if (!string.IsNullOrEmpty(res))
        {
            return new ResponseObject()
            {
                code = "00",
                status = true,
                message = "Login Succeeded",
                secToken = res
            };
        }

        return new ResponseObject()
        {
            code = "03",
            status = false,
            message = "Login failed"
        };
    }

    [HttpPost("Logout")]
    [Authorize]
    public ResponseObject Logout()
    {
        HttpContext.Session.Clear();
        return new ResponseObject()
        {
            code = "00",
            message = "User logout successful",
            status = true
        };
    }

    [AllowAnonymous]
    [HttpGet("ping")]
    public string ping()
    {
        return "pong";
    }
}