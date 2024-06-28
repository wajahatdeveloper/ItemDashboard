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

public class ItemsAdderService : IItemsAdderService
{
    private readonly IItemsRepository _itemsRepository;

    public ItemsAdderService(IItemsRepository itemsRepository)
    {
        _itemsRepository = itemsRepository;
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

        // add to repository
        await _itemsRepository.AddItem(item);

        // convert the domain object into response type
        return item.ToItemResponse();
    }
}
