using ECOM.Data;
using ECOM.Entities;
using ECOM.Models;
using Microsoft.EntityFrameworkCore;

namespace ECOM.Queries;

public class UserQuery : BaseQuery<User>, IUserQuery
{
    public UserQuery(AppDbContext context) : base(context.Set<User>(), context)
    {
    }
    
    public async Task<User?> GetByEmailAsync(string requestEmail)
    {
        try
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(u => u.Email == requestEmail);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }

    public async Task<IEnumerable<UserDto>> GetAllAsync()
    {
        try
        {
            var result = await DbSet.AsNoTracking().Select(u => new UserDto
            {
                Email = u.Email,
                FullName = u.FullName
            }).ToListAsync();

            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return [];
        }
    }
}