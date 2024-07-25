using ItemDashboard.Core.Entities;
using ItemDashboard.Infrastructure.ServicesContracts;
using Microsoft.AspNetCore.Mvc;

namespace ItemDashboard.UI.Areas.POS.Controllers;

[Area("POS")]
[Route("api/items/[action]")]
[ApiController]
public class ItemsApiController : ControllerBase
{
	private readonly IItemsService itemsService;

	public ItemsApiController(IItemsService itemsService)
	{
		this.itemsService = itemsService;
	}

	// GET: api/items
	[HttpGet]
	[Route("")]
	public async Task<ActionResult<IEnumerable<Item>>> GetItems()
	{
		var items = await itemsService.GetAllItems();
		return new ActionResult<IEnumerable<Item>>(items);
	}

	// GET: api/items/55555-55555-55555
	[HttpGet]
	[Route("{id}")]
	public async Task<ActionResult<Item>> GetItem(Guid id)
	{
		var item = await itemsService.GetItemByID(id);

		if (item == null)
		{
			return NotFound();
		}

		return new ActionResult<Item>(item);
	}

	// PUT: api/items/55555-55555-55555
	// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
	[HttpPut]
	[Route("{id}")]
	public async Task<IActionResult> PutItem(Item request)
	{
		var itemResponse = await itemsService.UpdateItem(request);
		if (itemResponse == null)
		{
			return NotFound();
		}

		return NoContent();
	}

	// POST: api/items
	// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
	[HttpPost]
	[Route("")]
	public async Task<ActionResult<Item>> PostItem([FromForm][FromBody] Item request)
	{
		var itemResponse = await itemsService.AddItem(request);

		return CreatedAtAction(nameof(GetItem), new { id = itemResponse.Id }, itemResponse);
	}

	// DELETE: api/items/55555-55555-55555
	[HttpDelete]
	[Route("{id}")]
	public async Task<IActionResult> DeleteItem(Guid id)
	{
		bool response = await itemsService.DeleteItemByID(id);

		if (response == false)
		{
			return NotFound();
		}

		return NoContent();
	}

	private bool ItemExists(Guid id)
	{
		return itemsService.ItemExists(id);
	}
}
