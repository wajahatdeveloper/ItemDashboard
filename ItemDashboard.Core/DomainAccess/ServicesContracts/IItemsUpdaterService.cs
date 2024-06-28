using ItemDashboard.Core.Supports.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemDashboard.Core.DomainAccess.ServicesContracts;

/// <summary>
/// Represents business logic for Updating Existing Item Entity
/// </summary>
public interface IItemsUpdaterService
{
    /// <summary>
    /// Updates an Existing Item Entity
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<ItemResponse> UpdateItem(ItemUpdateRequest request);
}
