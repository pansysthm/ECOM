using ECOM.Models;

namespace ECOM.Helper;

public interface IUserValidation
{
    bool Validation(CreateUserRequest user);
}