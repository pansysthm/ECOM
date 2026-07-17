using ECOM.Data;
using Microsoft.EntityFrameworkCore;

namespace ECOM.Queries;

public class BaseQuery<T> : IBaseQuery<T> where T : class
{
    protected readonly AppDbContext Context;
    protected readonly DbSet<T> DbSet;

    public BaseQuery(DbSet<T> dbSet, AppDbContext context)
    {
        DbSet = context.Set<T>();
        Context = context;
    }
    
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}