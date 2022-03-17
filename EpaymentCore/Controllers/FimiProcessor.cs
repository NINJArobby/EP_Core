using System.Security.Claims;
using FimiEngine;
using FimiEngine.HelpingClasses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LogLevel = NLog.LogLevel;

namespace EpaymentCore.Controllers;

[ApiController]
[Route("/api/[controller]")]
[Authorize]
public class FimiProcessor : ControllerBase
{
    private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();
    private FimiConfigManager _configuration;
    private ClaimsPrincipal currentUser;

    public FimiProcessor(IConfiguration _configuration)
    {
        this._configuration = new FimiConfigManager(_configuration);
    }

    bool isAuthorised()
    {
        currentUser = HttpContext.User;
        if (currentUser.HasClaim(c => c.Type == "Super") && currentUser.HasClaim(c => c.Type == "FimiUser"))
            return true;
        _logger.Log(LogLevel.Error, "Unauthorised Action:Setup request user is:" + currentUser);
        return false;
    }

    [HttpPost("SearchTransaction")]
    public IEnumerable<FimiTransaction> SearchTransaction(FimiSearchClass options)
    {
        if (isAuthorised() && currentUser.HasClaim(c => c.Type == "Reports"))
            return Fimi.SearchTransaction(options, _configuration.FimiDbConnection);
        HttpContext.Response.StatusCode = 403;
        return null;
    }

    [HttpPost("RetryFailedTransaction")]
    public bool RetryFailedTransaction(FimiTransaction options)
    {
        if (isAuthorised() && currentUser.HasClaim(c => c.Type == "Modify"))
            return Fimi.RetryFailedTransaction(options, _configuration.FimiDbConnection);
        HttpContext.Response.StatusCode = 403;
        return false;
    }

    [HttpPost("CheckFimiServiceStatus")]
    public string CheckFimiServiceStatus(ServiceObject serviceObject)
    {
        if (isAuthorised() && currentUser.HasClaim(c => c.Type == "Service"))
            return Fimi.CheckFimiServiceStatus(serviceObject.ServiceName, serviceObject.MachineName, serviceObject.OS);
        HttpContext.Response.StatusCode = 403;
        return "UnAuthorised";
    }

    [HttpPost("StartFimiService")]
    public string StartFimiService(ServiceObject serviceObject)
    {
        if (isAuthorised() && currentUser.HasClaim(c => c.Type == "Service"))
            return Fimi.StartFimiService(serviceObject.ServiceName, serviceObject.MachineName, serviceObject.OS);
        HttpContext.Response.StatusCode = 403;
        return "UnAuthorised";
    }

    [HttpPost("StopFimiService")]
    public string StopFimiService(ServiceObject serviceObject)
    {
        if (isAuthorised() && currentUser.HasClaim(c => c.Type == "Service"))
            return Fimi.StopFimiService(serviceObject.ServiceName, serviceObject.MachineName, serviceObject.OS);
        HttpContext.Response.StatusCode = 403;
        return "UnAuthorised";
    }
}