using Microsoft.EntityFrameworkCore;
using Store.BLL.Contracts;
using Store.BLL.Services;
using Store.DAL.Contracts;
using Store.DAL.EFDbContext;
using Store.DAL.Repositories;
using Store.DAL.UnitOfWorks;

namespace Store.Infrastructure
{
	public static class ServiceConfigurations
	{
		public static void Registration(this WebApplicationBuilder builder)
		{
			builder.Services.AddScoped<ICartBLL, CartBLL>();
			builder.Services.AddScoped<ICartRepository, CartRepository>();
			builder.Services.AddScoped<IProductBLL, ProductBLL>();
			builder.Services.AddScoped<IProductRepository, ProductRepository>();
			builder.Services.AddScoped<ICategoryBLL, CategoryBLL>();
			builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
			builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
			builder.Services.AddScoped<IOrderBLL, OrderBLL>();
			builder.Services.AddScoped<IOrderRepository, OrderRepository>();

			builder.Services.AddDbContext<SDbContext>(c => c.UseSqlServer("Password=12345;Persist Security Info=True;User ID=sa;Initial Catalog=Store;Data Source=.;TrustServerCertificate=Yes"));
		}
	}
}
