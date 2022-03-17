using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EpaymentCore.Controllers;

[ApiController]
[Route("/api/[controller]")]
[Authorize]
public class PromptController : ControllerBase
{
    // GET
}