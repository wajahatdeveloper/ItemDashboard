using ItemDashboard.Core.Supports.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemDashboard.Core.DomainAccess.ServicesContracts;

/// <summary>
/// Represents business logic for Deleting Existing Item Entity
/// </summary>
public interface IItemsDeleterService
{
    /// <summary>
    /// Deletes an Existing Item based on the given ID
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<bool> DeleteItemByID(Guid id);
}
