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

public class ItemsUpdaterService : IItemsUpdaterService
{
    private readonly IItemsRepository _itemsRepository;

    public ItemsUpdaterService(IItemsRepository itemsRepository)
    {
        _itemsRepository = itemsRepository;
    }

    public async Task<ItemResponse> UpdateItem(ItemUpdateRequest request)
    {
        // check if request is not null
        if (request == null) throw new ArgumentNullException(nameof(request));

        // model validation
        ValidationHelper.ModelValidation(request);

        // retreive domain object from repository
        Item? item = await _itemsRepository.GetItemById(request.Id);

        // validate retreived domain object
        if (item == null)
        {
            throw new ArgumentException("The given item id doesn't exist");
        }

        // update all details
        item.Name = request.Name;
        item.Description = request.Description;

        // update object in repository
        await _itemsRepository.UpdateItem(item);

        // convert the domain object into response type
        return item.ToItemResponse();
    }
}
