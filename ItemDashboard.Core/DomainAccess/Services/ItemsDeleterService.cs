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

public class ItemsDeleterService : IItemsDeleterService
{
    private readonly IItemsRepository _itemsRepository;

    public ItemsDeleterService(IItemsRepository itemsRepository)
    {
        _itemsRepository = itemsRepository;
    }

    public async Task<bool> DeleteItemByID(Guid id)
    {
        // check if request is not null
        if (id == null) throw new ArgumentNullException(nameof(id));

        // retreive domain object from repository
        Item? item = await _itemsRepository.GetItemById(id);

        // validate retreived domain object
        if (item == null) return false;

        // delete object from repository
        await _itemsRepository.DeleteItemById(id);

        // return success
        return true;
    }
}
