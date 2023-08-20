using Store.DAL.Models;

namespace Store.DAL.Contracts;

public interface ICategoryRepository
{
	Task<Category?> GetProduct(int id);
	Task<Category?> GetById(int id);
	Task<List<Category>> SelectCategory();
}
