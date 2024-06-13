using Microsoft.AspNetCore.Mvc;

namespace ItemDashboard.UI.Areas.Support.Controllers;

[Area("Support")]
public class HomeController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
}
