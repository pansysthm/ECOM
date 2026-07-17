namespace ECOM.Repositories;

public interface IBaseCommand<T> : IDisposable where T : class
{
    Task<bool> CreateAsync(T entity);
}