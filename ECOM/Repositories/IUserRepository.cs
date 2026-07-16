using ECOM.Entities;

namespace ECOM.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<bool> Create(User user);
    Task<bool> IsExistedByEmail(string email);
}