using Microsoft.AspNetCore.Mvc;

namespace CorePortal.Controllers;

[Route("[controller]")]
public class StartController : Controller
{
    [HttpGet]
    public IActionResult Homepage()
    {
        return View();
    }
}