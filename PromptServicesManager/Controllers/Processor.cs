using Microsoft.AspNetCore.Mvc;
using PromptServicesManager.HelpingClasses;

namespace PromptServicesManager.Controllers;

[ApiController]
[Route("[controller]")]
public class Processor : ControllerBase
{
    [HttpGet("Ping")]
    public string Ping()
    {
        return "pong";
    }

    [HttpPost("ToggleService")]
    public ResponseObject ToggleService(ServiceRequestObject data)
    {
        return ServicesUtility.ToggleService(data);
    }

    [HttpPost("CheckServiceStatus")]
    public string CheckServiceStatus(ServiceRequestObject data)
    {
        return ServicesUtility.CheckServiceStatus(data);
    }
}