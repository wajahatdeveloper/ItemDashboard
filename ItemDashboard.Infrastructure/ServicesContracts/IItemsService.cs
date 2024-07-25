using ItemDashboard.Core.Entities;

namespace ItemDashboard.Infrastructure.ServicesContracts;

public interface IItemsService
{
	Task<Item> AddItem(Item request);
	Task<bool> DeleteItemByID(Guid id);
	Task<IEnumerable<Item>> GetAllItems();
	Task<Item?> GetItemByID(Guid id);
	Task<Item> UpdateItem(Item request);
	bool ItemExists(Guid id);
}