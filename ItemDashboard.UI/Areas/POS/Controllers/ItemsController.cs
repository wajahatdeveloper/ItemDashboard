using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ItemDashboard.Core.Domain.Entities;
using ItemDashboard.Infrastructure;
using ItemDashboard.Infrastructure.ServicesContracts;
using ItemDashboard.Core.Supports.DTO;

namespace ItemDashboard.UI.Areas.POS.Controllers;

[Area("POS")]
public class ItemsController : Controller
{
    private readonly ILogger<ItemsController> _logger;
    private readonly IItemsService itemsService;

    public ItemsController(ILogger<ItemsController> logger, IItemsService itemsService)
    {
        this._logger = logger;
        this.itemsService = itemsService;
    }

    // GET: Items
     [HttpGet]
     [Route("/")]
     public async Task<IActionResult> Index()
     {
         // get data to populate the index view
         var items = await itemsService.GetAllItems();

         // render and return the index view
         return View(items.ToList());
     }

    // GET: Items/Details/55555-55555-55555
    [HttpGet]
    [Route("[action]/{id}")]
    public async Task<IActionResult> Details(Guid id)
     {
        // get data to populate the details view
        ItemResponse? itemResponse = await itemsService.GetItemByID(id);

        // render and return the details view
        // in case of null data will produce toast and redirect to Index (in razor view)
        return View(itemResponse);
     }

    // GET: Items/Create
    [HttpGet]
    [Route("/[action]")]
    public IActionResult Create()
     {
        // render and return the create new item view
         return View();
     }

    // GET: Items/Edit/55555-55555-55555
    [HttpGet]
    [Route("[action]/{id}")]
    public async Task<IActionResult> Edit(Guid id)
     {
        // get data to populate the edit view
        ItemResponse? item = await itemsService.GetItemByID(id);

        ItemUpdateRequest? updateRequest = item?.ToItemUpdateRequest();

        // render and return the edit view
        // in case of null data will produce toast and redirect to Index (in razor view)
        return View(updateRequest);
     }

    // GET: Items/Delete/55555-55555-55555
    [HttpGet]
    [Route("[action]/{id}")]
    public async Task<IActionResult> Delete(Guid id)
     {
        // get data to populate the delete view
        ItemResponse? itemResponse = await itemsService.GetItemByID(id);

        // render and return the delete view
        // in case of null data will produce toast and redirect to Index (in razor view)
        return View(itemResponse);
     }
}
