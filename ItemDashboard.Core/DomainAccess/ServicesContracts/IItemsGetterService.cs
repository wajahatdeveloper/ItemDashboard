using ItemDashboard.Core.Supports.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemDashboard.Core.DomainAccess.ServicesContracts;

/// <summary>
/// Represents business logic for Retreiving Item Entities
/// </summary>
public interface IItemsGetterService
{
    /// <summary>
    /// Returns an Item Object based on the given ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<ItemResponse?> GetItemByID(Guid id);

    /// <summary>
    /// Returns all Items from the List
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<ItemResponse>> GetAllItems();
}
