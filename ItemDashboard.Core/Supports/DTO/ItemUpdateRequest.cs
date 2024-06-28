using ItemDashboard.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemDashboard.Core.Supports.DTO;

/// <summary>
/// Acts as a DTO for updating an existing person
/// Validates data before updation to ensure a clean domain
/// </summary>
public class ItemUpdateRequest
{
    [Required(ErrorMessage = "Item ID cannot be blank")]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Item Name cannot be blank")]
    public string Name { get; set; } = "";

    [Required(ErrorMessage = "Item Description cannot be blank")]
    public string Description { get; set; } = "";

    /// <summary>
    /// Converts the current DTO Object to Domain Object
    /// </summary>
    /// <returns></returns>
    public Item ToItem()
    {
        return new Item { Id = Id, Name = Name, Description = Description };
    }
}
