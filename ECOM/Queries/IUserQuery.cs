using ECOM.Entities;
using ECOM.Models;

namespace ECOM.Queries;

public interface IUserQuery
{
    Task<User?> GetByEmailAsync(string requestEmail);
    Task<IEnumerable<UserDto>> GetAllAsync();
}