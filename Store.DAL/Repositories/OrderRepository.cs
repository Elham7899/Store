using Store.DAL.Contracts;
using Store.DAL.EFDbContext;
using Store.DAL.Models;

namespace Store.DAL.Repositories;

public class OrderRepository : IOrderRepository
{
	private readonly SDbContext _dbContext;

	public OrderRepository(SDbContext sDbContext)
	{
		_dbContext = sDbContext;
	}
	public void AddToOrder(Order order)
	{
		_dbContext.Orders.Add(order);
	}
}
