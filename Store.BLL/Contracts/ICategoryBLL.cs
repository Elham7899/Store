using Store.DAL.Models;

namespace Store.BLL.Contracts;

public interface ICategoryBLL
{
	Task<List<Category?>> GetCategories();
	Task<Category?> GetProduct(int id);
}
