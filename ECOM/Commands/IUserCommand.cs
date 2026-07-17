using ECOM.Entities;

namespace ECOM.Repositories;

public interface IUserCommand : IBaseCommand<User>
{
    Task<bool> IsExistedByEmailAsync(string email);
}