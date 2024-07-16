using ItemDashboard.Core.Domain.Entities;
using ItemDashboard.Core.DomainAccess.ServicesContracts;
using ItemDashboard.Core.Supports.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ItemDashboard.UI.Areas.POS.Controllers;

[Area("POS")]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IItemsGetterService _itemsGetterService;

    public HomeController(ILogger<HomeController> logger, IItemsGetterService itemsGetterService)
    {
        _logger = logger;
        _itemsGetterService = itemsGetterService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        _logger.LogInformation("List all Items");

        var items = await _itemsGetterService.GetAllItems();

        return View(items.ToList());
    }

    [HttpPost]
    public async Task<IActionResult> EditItem()
    {
        _logger.LogInformation("Edit Single Item");

        var items = await _itemsGetterService.GetAllItems();

        return View(items.ToList());
    }
}