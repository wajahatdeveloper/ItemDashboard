using ItemDashboard.Core.Domain.Entities;
using System;
using System.Collections.Generic;

namespace ItemDashboard.Core.Supports.DTO;

/// <summary>
/// Acts as a DTO used as return type from domain
/// </summary>
public class ItemResponse : IEquatable<ItemResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";

    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public DateTime CreatedBy { get; set; }
    public DateTime UpdatedBy { get; set; }

    public bool Equals(ItemResponse? other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        return Id == other.Id && Name == other.Name && Description == other.Description;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}

public static class ItemExtensions
{
    public static ItemResponse ToItemResponse(this Item item)
    {
        return new ItemResponse()
        {
            Id = item.Id,

            Name = item.Name,
            Description = item.Description,

            CreatedDate = item.CreatedDate,
            UpdatedDate = item.UpdatedDate,
           /* CreatedBy = item.CreatedBy,
            UpdatedBy = item.UpdatedBy,*/
        };
    }
}