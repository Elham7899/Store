namespace Store.DAL.Contracts;

public interface IUnitOfWork
{
    Task Commit();
}
