using ItemDashboard.Core.Supports.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemDashboard.Core.DomainAccess.ServicesContracts;

/// <summary>
/// Represents business logic for Adding New Item Entity
/// </summary>
public interface IItemsAdderService
{
    /// <summary>
    /// Adds an Item Object to List of Countries
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<ItemResponse> AddItem(ItemAddRequest request);
}
