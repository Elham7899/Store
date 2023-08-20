using Store.BLL.Contracts;
using Store.DAL.Contracts;
using Store.DAL.Models;

namespace Store.BLL.Services;

public class ProductBLL : IProductBLL
{
	private readonly IProductRepository _productRpository;

	public ProductBLL(IProductRepository productRepository)
	{
		_productRpository = productRepository;
	}

	public List<Product?> GetProduct(int id)
	{
		return _productRpository.Select(id);
	}
}
