using Microsoft.EntityFrameworkCore;
using Store.DAL.Contracts;
using Store.DAL.EFDbContext;
using Store.DAL.Models;

namespace Store.DAL.Repositories;

public class ProductRepository : IProductRepository
{
	private readonly SDbContext _dbContext;

	public ProductRepository(SDbContext sDbContext)
	{
		_dbContext = sDbContext;
	}

	public List<Product> Select(int id)
	{
		return _dbContext.Products.Where(p => p.Category.Id == id).Include(a => a.Category).ToList();
	}

	public async Task<Product?> SelectProduct(int id)
	{
		return await _dbContext.Products.SingleOrDefaultAsync(p => p.Id == id);
	}
}
