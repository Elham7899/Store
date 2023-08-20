using Store.DAL.Models;

namespace Store.DAL.Contracts;

public interface ICartRepository
{
	Task<Cart?> GetCartProduct(int id);
	Task<Cart> GetCart();
	void Insert(Cart cart);
	Task DeleteCart();
}
