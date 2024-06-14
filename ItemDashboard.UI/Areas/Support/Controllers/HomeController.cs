using Microsoft.AspNetCore.Mvc;

namespace ItemDashboard.UI.Areas.Support.Controllers;

[Area("Support")]
[Route("[area]/[controller]")]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index()
    {
        _logger.LogInformation("Hello from support!");

        return View();
    }
}
