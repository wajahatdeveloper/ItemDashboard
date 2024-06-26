using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace ItemDashboard.Core.Domain.Entities;

/// <summary>
/// Item Domain Model Class
/// </summary>
public class Item
{
    /// <summary>
    /// INFRASTRUCTURE DATA
    /// </summary>
    [Key]
    public Guid Id { get; set; }

    /// <summary>
    /// MAIN DATA
    /// </summary>
    [Required]
    [StringLength(40)] //nvarchar(40)
    public string Name { get; set; } = "";
    [Required]
    [StringLength(200)] //nvarchar(200)
    public string Description { get; set; } = "";
    
    /// <summary>
    /// TRACKING DATA
    /// </summary>
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public DateTime CreatedBy { get; set; }
    public DateTime UpdatedBy { get; set; }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}
