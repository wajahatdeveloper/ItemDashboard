﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ItemDashboard.Infrastructure;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
	public ApplicationDbContext CreateDbContext(string[] args)
	{
		var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
		optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ItemsDb;Trusted_Connection=True;MultipleActiveResultSets=true");

		return new ApplicationDbContext(optionsBuilder.Options);
	}
}
