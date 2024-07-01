using ItemDashboard.Core.Domain.Entities;
using System;
using System.Collections.Generic;

namespace ItemDashboard.Core.Domain.RepositoryContracts;

/// <summary>
/// Represents data access interface for managing item entity
/// </summary>
public interface IItemsRepository
{
    /// <summary>
    /// Basic CRUD Methods
    /// </summary>
    Task<Item> AddItem(Item item);
    Task<Item> UpdateItem(Item item);
    Task<bool> DeleteItemById(Guid id);
    Task<Item?> GetItemById(Guid id);

    /// <summary>
    /// Advanced CRUD Methods
    /// </summary>
    Task<IEnumerable<Item>> GetAllItems();
}
