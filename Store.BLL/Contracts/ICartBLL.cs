using Store.DAL.Models;

namespace Store.BLL.Contracts
{
	public interface ICartBLL
	{
		Task InsertPrduct(int productId);
		Task<Cart> GetProducts();
		Task DeleteCartProducts();
		Task<Cart> DeleteProduct(int id);
	}
}
