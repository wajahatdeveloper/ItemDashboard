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
	[Route("details/{id}")]
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
	[Route("/create")]
	public IActionResult Create()
	{
		// render and return the create new item view
		return View();
	}

    // POST: Items/Create
    [HttpPost]
    [Route("/create")]
    public async Task<IActionResult> Create(Item item)
    {
		// create new item in the database using the request data
		Item createdItem = await itemsService.AddItem(item);

        // redirect to index view to show the list of all items
        return RedirectToAction(nameof(Index));
    }

    // GET: Items/Edit/55555-55555-55555
    [HttpGet]
	[Route("edit/{id}")]
	public async Task<IActionResult> Edit(Guid id)
	{
		// get data to populate the edit view
		Item? item = await itemsService.GetItemByID(id);

		// render and return the edit view
		// in case of null data will produce toast and redirect to Index (in razor view)
		return View(item);
	}

    // POST: Items/Edit/55555-55555-55555
    [HttpPost]
    [Route("edit/{id}")]
    public async Task<IActionResult> Edit(Item item)
    {
        // get data to populate the edit view
        Item? fetchedItem = await itemsService.GetItemByID(item.Id);

		// short circuit to all items list with an error toast
		if (fetchedItem == null)
		{
			return RedirectToAction(nameof(Index));
		}

		// update item in database based on new item edits
		Item updatedItem = await itemsService.UpdateItem(item);

        // redirect to index view to show the list of all items
        return RedirectToAction(nameof(Index));
    }

    // GET: Items/Delete/55555-55555-55555
    [HttpGet]
	[Route("delete/{id}")]
	public async Task<IActionResult> Delete(Guid id)
	{
		// get data to populate the delete view
		Item? itemResponse = await itemsService.GetItemByID(id);

		// render and return the delete view
		// in case of null data will produce toast and redirect to Index (in razor view)
		return View(itemResponse);
	}

	// POST: Items/Delete/55555-55555-55555
	[HttpPost]
	[Route("delete/{id}")]
	public async Task<IActionResult> Delete(Item item)
	{
		// get data to populate the delete view
		Item? fetchedItem = await itemsService.GetItemByID(item.Id);

		// short circuit to all items list with an error toast
		if (fetchedItem == null)
		{
			return RedirectToAction(nameof(Index));
		}

		// update item in database based on new item edits
		bool isDeleted = await itemsService.DeleteItemByID(item.Id);

		// short circuit to all items list with an error toast
		if (!isDeleted)
		{
			return RedirectToAction(nameof(Index));
		}

		// show success toast

		// redirect to index view to show the list of all items
		return RedirectToAction(nameof(Index));
	}
}
