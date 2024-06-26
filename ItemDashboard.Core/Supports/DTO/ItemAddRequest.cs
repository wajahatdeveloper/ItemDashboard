using ItemDashboard.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemDashboard.Core.Supports.DTO;

/// <summary>
/// Acts as a DTO for inserting a new person
/// Validates data before insertion to ensure a clean domain
/// </summary>
public class ItemAddRequest
{
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
        return new Item { Name = Name, Description = Description };
    }
}
