using ItemDashboard.Core.Domain.Entities;
using ItemDashboard.Core.Domain.RepositoryContracts;
using ItemDashboard.Core.DomainAccess.ServicesContracts;
using ItemDashboard.Core.Supports.DTO;
using ItemDashboard.Core.Supports.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemDashboard.Core.DomainAccess.Services;

public class ItemsGetterService : IItemsGetterService
{
    private readonly IItemsRepository _itemsRepository;

    public ItemsGetterService(IItemsRepository itemsRepository)
    {
        _itemsRepository = itemsRepository;
    }

    public async Task<IEnumerable<ItemResponse>> GetAllItems()
    {
        // retreive all domain objects from repository
        IEnumerable<Item> items = await _itemsRepository.GetAllItems();

        // convert all domain objects to response objects
        IEnumerable<ItemResponse> result = items.Select(x => x.ToItemResponse());

        // return response objects as result
        return result;
    }

    public async Task<ItemResponse?> GetItemByID(Guid id)
    {
        // check if request is not null
        if (id == null) throw new ArgumentNullException(nameof(id));

        // retreive domain object from repository
        Item? item = await _itemsRepository.GetItemById(id);

        // validate retreived domain object
        if (item == null) return null;

        // return response object as result
        return item.ToItemResponse();
    }
}
