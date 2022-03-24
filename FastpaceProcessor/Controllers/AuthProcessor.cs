using System.Security.Claims;
using FastpaceProcessor.HelpingClasses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecurityEngine.HelpingClasses;

namespace FastpaceProcessor.Controllers;

[ApiController]
[Route("/authenticate/fineract-service-bus/")]
[Authorize]
public class Processor : ControllerBase
{
    private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();
    private ClaimsPrincipal currentUser;


    [HttpPost("Fineract-Login")]
    [AllowAnonymous]
    public AuthResopnseObject Login(string clientId, string credential)
    {
        var res = SecurityEngine.Authenticate.AuthenticateUser(new UserModel()
        {
            Username = clientId,
            Password = credential,
            Uid = 0
        });
        if (!string.IsNullOrEmpty(res))
        {
            return new AuthResopnseObject()
            {
                expiresIn = 86400,
                idToken = res,
                tokenType = "bearer",
                status = true
            };
        }

        return new AuthResopnseObject()
        {
            expiresIn = 86400,
            idToken = res,
            tokenType = "bearer",
            status = false
        };
    }

    [HttpPost("Logout")]
    [Authorize]
    public AuthResopnseObject Logout()
    {
        HttpContext.Session.Clear();
        return new AuthResopnseObject()
        {
            expiresIn = 0,
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