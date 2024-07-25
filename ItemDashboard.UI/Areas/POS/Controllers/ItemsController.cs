using ItemDashboard.Core.Entities;
using ItemDashboard.Infrastructure.ServicesContracts;
using Microsoft.AspNetCore.Mvc;

namespace ItemDashboard.UI.Areas.POS.Controllers;

[Area("POS")]
public class ItemsController : Controller
{
	private readonly ILogger<ItemsController> logger;
	private readonly IItemsService itemsService;

	public ItemsController(ILogger<ItemsController> logger, IItemsService itemsService)
	{
		this.logger = logger;
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
		Item? itemResponse = await itemsService.GetItemByID(id);

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

	// POST: Items/Edit/55555-55555-55555
	[HttpPost]
	[Route("[action]/{id}")]
	public async Task<IActionResult> Edit(Guid id)
	{
		// get data to populate the edit view
		Item? item = await itemsService.GetItemByID(id);

		// render and return the edit view
		// in case of null data will produce toast and redirect to Index (in razor view)
		return View(item);
	}

	// GET: Items/Delete/55555-55555-55555
	[HttpGet]
	[Route("[action]/{id}")]
	public async Task<IActionResult> Delete(Guid id)
	{
		// get data to populate the delete view
		Item? itemResponse = await itemsService.GetItemByID(id);

		// render and return the delete view
		// in case of null data will produce toast and redirect to Index (in razor view)
		return View(itemResponse);
	}
}
