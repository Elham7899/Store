using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.DAL.Models;

namespace Store.DAL.Mappings;

public class OrderMapping : IEntityTypeConfiguration<Order>
{
	public void Configure(EntityTypeBuilder<Order> builder)
	{
		builder.ToTable("order");

		builder.HasMany(o => o.OrderItem).WithOne();
	}
}
