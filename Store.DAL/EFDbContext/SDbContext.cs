using Microsoft.EntityFrameworkCore;
using Store.DAL.Mappings;
using Store.DAL.Models;

namespace Store.DAL.EFDbContext;

public class SDbContext : DbContext
{
	public DbSet<Cart> Carts { get; set; }

	public DbSet<Product> Products { get; set; }

	public DbSet<Category> Categories { get; set; }

	public DbSet<Order> Orders { get; set; }

	public SDbContext(DbContextOptions options) : base(options)
	{

	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(CartsMapping).Assembly);
	}
}
