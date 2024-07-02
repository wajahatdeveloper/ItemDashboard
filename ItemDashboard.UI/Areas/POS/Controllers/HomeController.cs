using Microsoft.AspNetCore.Mvc;

namespace ItemDashboard.UI.Areas.POS.Controllers;

[Area("POS")]
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
        _logger.LogInformation("Hello from POS!");

        return View();
    }
}