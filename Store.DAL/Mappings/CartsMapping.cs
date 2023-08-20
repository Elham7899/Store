using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.DAL.Models;

namespace Store.DAL.Mappings;

public class CartsMapping : IEntityTypeConfiguration<Cart>
{
	public void Configure(EntityTypeBuilder<Cart> builder)
	{
		builder.ToTable("Cart");

		builder.HasMany(c => c.ProductItems).WithOne();
	}
}
