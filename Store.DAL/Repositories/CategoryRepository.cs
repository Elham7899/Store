using Microsoft.EntityFrameworkCore;
using Store.DAL.Contracts;
using Store.DAL.EFDbContext;
using Store.DAL.Models;

namespace Store.DAL.Repositories;

public class CategoryRepository : ICategoryRepository
{
	private readonly SDbContext _dbContext;

	public CategoryRepository(SDbContext sDbContext)
	{
		_dbContext = sDbContext;
	}

	public async Task<Category?> GetProduct(int id)
	{
		return await _dbContext.Categories.Include(c => c.Products).SingleOrDefaultAsync(c => c.Id == id);

	}

	public async Task<Category?> GetById(int id)
	{
		return await _dbContext.Categories.SingleOrDefaultAsync(c => c.Id == id);

	}

	public async Task<List<Category>> SelectCategory()
	{
		return await _dbContext.Categories.ToListAsync();
	}
}
