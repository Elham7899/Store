using Microsoft.EntityFrameworkCore;
using Store.DAL.Contracts;
using Store.DAL.EFDbContext;
using Store.DAL.Models;

namespace Store.DAL.Repositories;

public class CartRepository : ICartRepository
{
	private readonly SDbContext _dbcontext;

	public CartRepository(SDbContext sDbContext)
	{
		_dbcontext = sDbContext;
	}

	public async Task<Cart?> GetCartProduct(int id)
	{
		return await _dbcontext.Carts.Where(c => c.UserId == id).Include(p => p.ProductItems).ThenInclude(p => p.Product).SingleOrDefaultAsync();
	}

	public async Task<Cart?> GetCart()
	{
		return await _dbcontext.Carts.Where(c => c.Id == 1).Include(p => p.ProductItems).ThenInclude(p => p.Product).SingleOrDefaultAsync();
	}

	public void Insert(Cart cart)
	{
		_dbcontext.Carts.Add(cart);
	}

	public async Task DeleteCart()
	{
		var cart = await _dbcontext.Carts.Where(c => c.Id == 1).SingleOrDefaultAsync();

		_dbcontext.Carts.Remove(cart);
	}
}
