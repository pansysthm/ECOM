namespace ECOM.Repositories;

public interface IBaseRepository<T> : IDisposable where T : class
{
    Task<bool> Create(T entity);
}