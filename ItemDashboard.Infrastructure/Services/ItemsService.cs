using ItemDashboard.Core.Domain.Entities;
using ItemDashboard.Core.Supports.DTO;
using ItemDashboard.Core.Supports.Helpers;
using ItemDashboard.Infrastructure.ServicesContracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemDashboard.Infrastructure.Services;

public class ItemsService : IItemsService
{
    private readonly ApplicationDbContext dbContext;

    public ItemsService(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }    

    public async Task<ItemResponse> AddItem(ItemAddRequest request)
    {
        // check if request is not null
        if (request == null) throw new ArgumentNullException(nameof(request));

        // model validation
        ValidationHelper.ModelValidation(request);

        // convert request to domain type
        Item item = request.ToItem();

        // generate ID
        item.Id = Guid.NewGuid();

        // add to database
        dbContext.Items.Add(item);
        await dbContext.SaveChangesAsync();

        // convert the domain object into response type
        return item.ToItemResponse();
    }

    public async Task<IEnumerable<ItemResponse>> GetAllItems()
    {
        // retreive all domain objects from repository
        IEnumerable<Item> items = await dbContext.Items.ToListAsync();

        // convert all domain objects to response objects
        IEnumerable<ItemResponse> result = items.Select(x => x.ToItemResponse());

        // return response objects as result
        return result;
    }

    public async Task<ItemResponse?> GetItemByID(Guid id)
    {
        // retreive domain object from repository
        Item? item = await dbContext.Items.FindAsync(id);

        // validate retreived domain object
        if (item == null) return null;

        // return response object as result
        return item.ToItemResponse();
    }

    public async Task<bool> DeleteItemByID(Guid id)
    {
        // retreive domain object from repository
        Item? item = await dbContext.Items.FindAsync(id);

        // validate retreived domain object
        if (item == null) return false;

        dbContext.Items.RemoveRange(dbContext.Items.Where(x => x.Id == id));
        int rowsDeleted = await dbContext.SaveChangesAsync();

        return rowsDeleted > 0;
    }

    public async Task<ItemResponse> UpdateItem(ItemUpdateRequest request)
    {
        // check if request is not null
        if (request == null) throw new ArgumentNullException(nameof(request));

        // model validation
        ValidationHelper.ModelValidation(request);

        // retreive domain object from repository
        Item? item = await dbContext.Items.FindAsync(request.Id);

        // validate retreived domain object
        if (item == null)
        {
            throw new ArgumentException("The given item id doesn't exist");
        }

        // update all details
        item.Name = request.Name;
        item.Description = request.Description;

        // update object in repository
        Item? itemToUpdate = await dbContext.Items.FirstOrDefaultAsync(x => x.Id == item.Id);
        if (itemToUpdate == null) return new ItemResponse();

        itemToUpdate.Name = item.Name;
        itemToUpdate.Description = item.Description;
        itemToUpdate.CreatedDate = item.CreatedDate;
        itemToUpdate.UpdatedDate = item.UpdatedDate;

        int updatedRows = await dbContext.SaveChangesAsync();

        // convert the domain object into response type
        return item.ToItemResponse();
    }

    public bool ItemExists(Guid id)
    {
        return dbContext.Items.Any(e => e.Id == id);
    }
}