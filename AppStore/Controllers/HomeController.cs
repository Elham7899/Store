using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Store.BLL.Contracts;
using Store.DAL.Models;
using Store.Models;

namespace Store.Controllers
{
	public class HomeController : Controller
	{
		static int _categoryId;

		static List<Category> _categories;

		private readonly ICategoryBLL _categoryBLL;
		private readonly IProductBLL _productBLL;
		private readonly ICartBLL _cartBLL;
		private readonly IOrderBLL _orderBLL;
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger, ICategoryBLL categoryBLL, IProductBLL productBLL, ICartBLL cartBLL, IOrderBLL orderBLL)
		{
			_logger = logger;
			_categoryBLL = categoryBLL;
			_productBLL = productBLL;
			_cartBLL = cartBLL;
			_orderBLL = orderBLL;
		}
		public async Task<IActionResult> Index()
		{
			_categories = await _categoryBLL.GetCategories();

			ViewBag.Categories = _categories;

			return View(_categories);
		}

		public async Task<IActionResult> GetProducts(int categoryId)
		{
			_categoryId = categoryId;

			var productCategory = await _categoryBLL.GetProduct(categoryId);

			var categories = await _categoryBLL.GetCategories();

			var category = categories.Where(x => x.Id == categoryId).FirstOrDefault();

			category.Products = productCategory.Products;

			ViewBag.Categories = _categories;

			return View("Index", categories);
		}

		[HttpPost]
		public async Task<IActionResult> AddToCart(ProductDTO productDTO)
		{
			await _cartBLL.InsertPrduct(productDTO.ProductId);

			var productCategory = await _categoryBLL.GetProduct(_categoryId);

			var categories = (await _categoryBLL.GetCategories()).Select(x => new Category { Id = x.Id, Name = x.Name, }).ToList();

			var category = categories.Where(x => x.Id == _categoryId).FirstOrDefault();

			category.Products = productCategory.Products.OrderBy(p => p.Id).ToList();

			ViewBag.Categories = _categories;

			return View("Index", categories);
		}

		public async Task<IActionResult> AddingInCart(ProductDTO productDTO)
		{
			await _cartBLL.InsertPrduct(productDTO.ProductId);

			var cart = await _cartBLL.GetProducts();

			var categories = await _categoryBLL.GetCategories();

			ViewBag.Categories = _categories;

			return View("Cart", cart);
		}

		[HttpPost]
		public async Task<IActionResult> DeleteFromCart(ProductDTO productDTO)
		{
			var cart = await _cartBLL.DeleteProduct(productDTO.ProductId);

			var categories = await _categoryBLL.GetCategories();

			ViewBag.Categories = _categories;

			return View("Cart", cart);
		}

		[HttpPost]
		public async Task<IActionResult> AddToOrder()
		{
			await _orderBLL.AddToOrder();

			var cart = await _cartBLL.GetProducts();

			if (cart.ProductItems.Count == 0)
			{
				ViewBag.Message = "There Is No Order Here";
			}
			else
			{
				await _cartBLL.DeleteCartProducts();
				ViewBag.Message = "Your Order Saved!";
			}

			ViewBag.Categories = _categories;

			return View("Cart", cart);
		}

		public async Task<IActionResult> Cart()
		{
			var cart = await _cartBLL.GetProducts();

			ViewBag.Categories = _categories;

			return View(cart);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}

	public class ProductDTO
	{
		public int ProductId { get; set; }
	}
}