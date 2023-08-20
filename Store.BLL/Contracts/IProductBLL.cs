using Store.DAL.Models;

namespace Store.BLL.Contracts;

public interface IProductBLL
{
	List<Product> GetProduct(int id);
}
