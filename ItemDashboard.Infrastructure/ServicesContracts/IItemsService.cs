using ItemDashboard.Core.Supports.DTO;

namespace ItemDashboard.Infrastructure.ServicesContracts;

public interface IItemsService
{
    Task<ItemResponse> AddItem(ItemAddRequest request);
    Task<bool> DeleteItemByID(Guid id);
    Task<IEnumerable<ItemResponse>> GetAllItems();
    Task<ItemResponse?> GetItemByID(Guid id);
    Task<ItemResponse> UpdateItem(ItemUpdateRequest request);
    bool ItemExists(Guid id);
}