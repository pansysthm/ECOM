using ECOM.Data;
using ECOM.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECOM.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context.Set<User>(), context)
    {
    }
    
    public async Task<bool> IsExistedByEmail(string email)
    {
        return await DbSet.AnyAsync(u => u.Email == email);
    }
}