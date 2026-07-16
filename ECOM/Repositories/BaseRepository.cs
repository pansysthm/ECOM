using ECOM.Data;
using Microsoft.EntityFrameworkCore;

namespace ECOM.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected readonly AppDbContext Context;
    protected readonly DbSet<T> DbSet;

    public BaseRepository(DbSet<T> dbSet, AppDbContext context)
    {
        DbSet = context.Set<T>();
        Context = context;
    }

    public async Task<bool> Create(T entity)
    {
        await DbSet.AddAsync(entity);
        return await Context.SaveChangesAsync() > 0;
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}