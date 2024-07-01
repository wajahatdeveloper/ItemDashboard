using ItemDashboard.Core.Domain.Entities;
using ItemDashboard.Core.Domain.RepositoryContracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemDashboard.Infrastructure.Repositories;

public class ItemsRepository : IItemsRepository
{
    private readonly ApplicationDbContext _db;

    public ItemsRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Item> AddItem(Item item)
    {
        _db.Items.Add(item);
        await _db.SaveChangesAsync();
        return item;
    }

    public async Task<bool> DeleteItemById(Guid id)
    {
        _db.Items.RemoveRange(_db.Items.Where(x => x.Id == id));
        int rowsDeleted = await _db.SaveChangesAsync();
        return rowsDeleted > 0;
    }

    public async Task<IEnumerable<Item>> GetAllItems()
    {
        return await _db.Items.ToListAsync();
    }

    public async Task<Item?> GetItemById(Guid id)
    {
        return await _db.Items.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Item> UpdateItem(Item item)
    {
        Item? itemToUpdate = await _db.Items.FirstOrDefaultAsync(x=>x.Id == item.Id);
        if (itemToUpdate == null) return item;

        itemToUpdate.Name = item.Name;
        itemToUpdate.Description = item.Description;
        itemToUpdate.CreatedDate = item.CreatedDate;
        itemToUpdate.UpdatedDate = item.UpdatedDate;
        
        int updatedRows = await _db.SaveChangesAsync();
        return itemToUpdate;
    }
}
