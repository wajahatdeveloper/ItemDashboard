using ItemDashboard.Core.Domain.Entities;
using ItemDashboard.Core.Supports.DTO;
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

  /*  [HttpGet]
    [Route("[action]/{id}")]
    public async Task<IActionResult> Edit([FromRoute] Guid id)
    {
        // get data to populate the edit view
        ItemResponse? response = await _itemsGetterService.GetItemByID(id);
        if (response == null)
        {
            _logger.LogError($"Edit: ID {id} not found in Database");
            return RedirectToAction("Index");
        }

        ItemUpdateRequest updateRequest = response.ToItemUpdateRequest();

        // render and return the edit view
        return View(updateRequest);
    }

    [HttpPost("[action]/{id}")]
    public async Task<IActionResult> Update([FromRoute] Guid id , [FromBody] ItemUpdateRequest itemUpdateRequest)
    {
        // Fetch Item from Database
        var item = await _itemsGetterService.GetItemByID(id);

        // Internal Data Validation
        if (item == null)
        {
            _logger.LogError($"Edit Single Item, Fetch Item is null");
            return Json(new { error = "Invalid Item Object" });
        }

        ItemResponse itemResponse = await _itemsUpdaterService.UpdateItem(itemUpdateRequest);

        // Render Edit View
        return View(item);
    }*/
}