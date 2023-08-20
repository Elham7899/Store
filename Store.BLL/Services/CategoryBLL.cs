using Store.BLL.Contracts;
using Store.DAL.Contracts;
using Store.DAL.Models;

namespace Store.BLL.Services;

public class CategoryBLL : ICategoryBLL
{
	private readonly ICategoryRepository _categoryRepository;

	public CategoryBLL(ICategoryRepository categoryRepository)
	{
		_categoryRepository = categoryRepository;
	}

	public async Task<List<Category?>> GetCategories()
	{
		return await _categoryRepository.SelectCategory();
	}

	public async Task<Category?> GetProduct(int id)
	{
		return await _categoryRepository.GetProduct(id);
	}
}
