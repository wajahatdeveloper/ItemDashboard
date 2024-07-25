using ItemDashboard.Core.Entities;
using ItemDashboard.Core.Helpers;
using ItemDashboard.Infrastructure.ServicesContracts;
using Microsoft.EntityFrameworkCore;

namespace ItemDashboard.Infrastructure.Services;

public class ItemsService : IItemsService
{
	private readonly ApplicationDbContext dbContext;

	public ItemsService(ApplicationDbContext dbContext)
	{
		this.dbContext = dbContext;
	}

	public async Task<Item> AddItem(Item item)
	{
		// model validation
		ValidationHelper.ModelValidation(item);

		// generate ID
		item.Id = Guid.NewGuid();

		// add to database
		dbContext.Items.Add(item);
		await dbContext.SaveChangesAsync();

		// return newly created item
		return item;
	}

	public async Task<IEnumerable<Item>> GetAllItems()
	{
		// retreive all domain objects from repository
		IEnumerable<Item> items = await dbContext.Items.ToListAsync();

		// return response objects as result
		return items;
	}

	public async Task<Item?> GetItemByID(Guid id)
	{
		// retreive domain object from repository
		Item? item = await dbContext.Items.FindAsync(id);

		// validate retreived domain object
		if (item == null) return null;

		// return found object
		return item;
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

	public async Task<Item> UpdateItem(Item request)
	{
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

		await dbContext.SaveChangesAsync();

		// return the updated item
		return item;
	}

	public bool ItemExists(Guid id)
	{
		return dbContext.Items.Any(e => e.Id == id);
	}
}