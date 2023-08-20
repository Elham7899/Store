using Store.DAL.Models;

namespace Store.DAL.Contracts;

public interface IOrderRepository
{
	void AddToOrder(Order order);
}
