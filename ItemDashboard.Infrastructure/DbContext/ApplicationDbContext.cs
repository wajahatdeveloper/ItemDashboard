using ItemDashboard.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace ItemDashboard.Infrastructure;

public class ApplicationDbContext : DbContext
{
	public ApplicationDbContext(DbContextOptions options) : base(options)
	{
	}

	public virtual DbSet<Item> Items { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.Entity<Item>().ToTable("Items");

		string itemsJson = File.ReadAllText("Items_seed.json");
		List<Item>? items = JsonSerializer.Deserialize<List<Item>>(itemsJson);
		if (items == null)
		{
			throw new NullReferenceException(nameof(items));
		}

		foreach (Item item in items)
		{
			modelBuilder.Entity<Item>().HasData(item);
		}
	}
}
