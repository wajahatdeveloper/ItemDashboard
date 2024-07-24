using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ItemDashboard.Core.Domain.Entities;
using ItemDashboard.Infrastructure;
using ItemDashboard.Infrastructure.ServicesContracts;
using ItemDashboard.Core.Supports.DTO;

namespace ItemDashboard.UI.Areas.POS.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ItemsApiController : ControllerBase
{
    private readonly IItemsService itemsService;

    public ItemsApiController(IItemsService itemsService)
    {
        this.itemsService = itemsService;
    }

    // GET: api/ItemsApi
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ItemResponse>>> GetItems()
    {
        var items = await itemsService.GetAllItems();
        return new ActionResult<IEnumerable<ItemResponse>>(items);
    }

    // GET: api/ItemsApi/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ItemResponse>> GetItem(Guid id)
    {
        var item = await itemsService.GetItemByID(id);

        if (item == null)
        {
            return NotFound();
        }

        return new ActionResult<ItemResponse>(item);
    }

    // PUT: api/ItemsApi/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutItem(ItemUpdateRequest request)
    {
        var itemResponse = await itemsService.UpdateItem(request);
        if (itemResponse == null)
        {
            return NotFound();
        }

        return NoContent();
    }

    // POST: api/ItemsApi
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Item>> PostItem(ItemAddRequest request)
    {
        var itemResponse = await itemsService.AddItem(request);

        return CreatedAtAction(nameof(GetItem), new { id = itemResponse.Id }, itemResponse);
    }

    // DELETE: api/ItemsApi/5
    [HttpDelete("{id}")]
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
