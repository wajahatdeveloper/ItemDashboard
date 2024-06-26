using ItemDashboard.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemDashboard.Core.Domain.RepositoryContracts;

/// <summary>
/// Represents data access interface for managing item entity
/// </summary>
public interface IItemRepository
{
    /// <summary>
    /// Basic CRUD Methods
    /// </summary>
    Task<Item> AddItem(Item item);
    Task<Item> UpdateItem(Item item);
    Task DeleteItemById(int id);
    Task<Item> GetItemById(int id);

    /// <summary>
    /// Advanced CRUD Methods
    /// </summary>
    Task<IEnumerable<Item>> GetAllItems();
}
