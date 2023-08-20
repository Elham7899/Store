using Store.DAL.Contracts;
using Store.DAL.EFDbContext;

namespace Store.DAL.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
	private readonly SDbContext _dbContext;

	public UnitOfWork(SDbContext sDbContext)
	{
		_dbContext = sDbContext;
	}

	public async Task Commit()
	{
		await _dbContext.SaveChangesAsync();
	}
}
