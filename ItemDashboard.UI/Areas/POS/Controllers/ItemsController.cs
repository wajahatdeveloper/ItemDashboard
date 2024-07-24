using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ItemDashboard.Core.Domain.Entities;
using ItemDashboard.Infrastructure;

namespace ItemDashboard.UI.Areas.POS.Controllers;

[Area("POS")]
public class ItemsController : Controller
{
    private readonly ILogger<ItemsController> _logger;

    public ItemsController(ILogger<ItemsController> logger)
    {
        _logger = logger;
    }

    // GET: Items
   /* [HttpGet]
    [Route("/")]
    public async Task<IActionResult> Index()
    {
        // get data to populate the index view
        var items = await _itemsGetterService.GetAllItems();

        // render and return the index view
        return View(items.ToList());
    }

    // GET: Items/Details/5
    public async Task<IActionResult> Details(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var item = await _itemsGetterService.GetItemByID(id.Value);

        if (item == null)
        {
            return NotFound();
        }

        return View(item);
    }

    // GET: Items/Create
    public IActionResult Create()
    {
        return View();
    }

    // GET: Items/Edit/5
    public async Task<IActionResult> Edit(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var item = await _itemsGetterService.GetItemByID(id.Value);

        if (item == null)
        {
            return NotFound();
        }
        return View(item);
    }

    // GET: Items/Delete/5
    public async Task<IActionResult> Delete(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var item = await _itemsGetterService.GetItemByID(id.Value);

        if (item == null)
        {
            return NotFound();
        }

        return View(item);
    }

    private bool ItemExists(Guid id)
    {
        return _itemsGetterService.GetAllItems().GetAwaiter().GetResult().Any(e => e.Id == id);
    }*/
}
