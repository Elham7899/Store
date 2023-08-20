using Store.DAL.Models;

namespace Store.DAL.Contracts;

public interface IProductRepository
{
    List<Product?> Select(int id);
	Task<Product> SelectProduct(int id);
}
