using ECOM.Data;
using ECOM.Entities;
using ECOM.Models;
using Microsoft.EntityFrameworkCore;

namespace ECOM.Repositories;

public class UserCommand : BaseCommand<User>, IUserCommand
{
    public UserCommand(AppDbContext context) : base(context.Set<User>(), context)
    {
    }
    
    public async Task<bool> IsExistedByEmailAsync(string email)
    {
        return await DbSet.AnyAsync(u => u.Email == email);
    }
}