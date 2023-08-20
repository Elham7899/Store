using Store.BLL.Contracts;
using Store.DAL.Contracts;
using Store.DAL.Models;

namespace Store.BLL.Services;

public class OrderBLL : IOrderBLL
{
	private readonly ICartRepository _cartRepository;
	private readonly IUnitOfWork _unitOfWork;
	private readonly IOrderRepository _orderRepository;

	public OrderBLL(ICartRepository cartRepository, IUnitOfWork unitOfWork, IOrderRepository orderRepository)
	{
		_cartRepository = cartRepository;

		_unitOfWork = unitOfWork;

		_orderRepository = orderRepository;
	}
	public async Task AddToOrder()
	{
		var cart = await _cartRepository.GetCart();

		var order = new Order();

		order.OrderItem = new List<OrderItem>();

		foreach (var item in cart.ProductItems)
		{
			var orderItem = new OrderItem() { Products = item.Product, Count = 1 };

			order.OrderItem.Add(orderItem);
		}

		order.Date = DateTime.Now;

		_orderRepository.AddToOrder(order);

		await _unitOfWork.Commit();
	}
}
