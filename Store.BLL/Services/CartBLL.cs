using Store.BLL.Contracts;
using Store.DAL.Contracts;
using Store.DAL.Models;

namespace Store.BLL.Services;

public class CartBLL : ICartBLL
{
	private readonly ICartRepository _cartRepository;
	private readonly IUnitOfWork _unitOfWork;
	private readonly IProductRepository _productRepository;

	public CartBLL(ICartRepository cartRepository, IUnitOfWork unitOfWork, IProductRepository productRepository)
	{
		_cartRepository = cartRepository;

		_unitOfWork = unitOfWork;

		_productRepository = productRepository;
	}

	public async Task InsertPrduct(int productId)
	{
		var product = await _productRepository.SelectProduct(productId);

		var cartProduct = await _cartRepository.GetCartProduct(1);

		var productItem = cartProduct.ProductItems.Where(p => p.Product != null && p.Product.Id == productId).FirstOrDefault();

		if (productItem is null)
		{
			productItem = new ProductItem() { Product = product, Count = 1 };

			cartProduct.ProductItems.Add(productItem);
		}
		else
		{
			productItem.Count++;
		}

		await _unitOfWork.Commit();
	}

	public async Task<Cart> GetProducts()
	{
		return await _cartRepository.GetCart();
	}

	public async Task DeleteCartProducts()
	{
		var cart = await _cartRepository.GetCartProduct(1);

		cart.ProductItems.Clear();

		await _unitOfWork.Commit();
	}

	public async Task<Cart> DeleteProduct(int id)
	{
		var product = await _productRepository.SelectProduct(id);

		var cart = await _cartRepository.GetCartProduct(1);

		var productItem = cart.ProductItems.Where(p => p.Product.Id == id).FirstOrDefault();

		if (productItem.Count > 1)
		{
			productItem.Count--;
		}
		else
		{
			cart.ProductItems.Remove(productItem);
		}

		await _unitOfWork.Commit();

		return cart;
	}
}
