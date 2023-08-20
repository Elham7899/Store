using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.DAL.Models;

namespace Store.DAL.Mappings;

public class ProductMapping : IEntityTypeConfiguration<Product>
{
	public void Configure(EntityTypeBuilder<Product> builder)
	{
		builder.ToTable("ProductInfo");

		builder.HasOne(c => c.Category).WithMany(c => c.Products);
	}
}
