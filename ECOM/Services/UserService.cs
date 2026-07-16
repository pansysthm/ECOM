using ECOM.Entities;
using ECOM.Helper;
using ECOM.Models;
using ECOM.Repositories;

namespace ECOM.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IEncryptPasswordHelper _encryptPasswordHelper;
    private readonly IUserValidation _userValidation;

    public UserService(IUserRepository userRepository, IEncryptPasswordHelper encryptPasswordHelper, IUserValidation userValidation)
    {
        _userRepository = userRepository;
        _encryptPasswordHelper = encryptPasswordHelper;
        _userValidation = userValidation;
    }

    public async Task<bool> Create(CreateUserRequest request)
    {
        try
        {
            var isUserExisted = await CheckExistedUser(request.Email);

            if (isUserExisted) return false;

            if (!_userValidation.Validation(request)) return false;
            
            var newUser = new User
            {
                Id = Guid.NewGuid(),
                Email = request.Email,
                FullName = request.FullName,
                PasswordHash = _encryptPasswordHelper.Encrypt(request.Password),
                CreatedAt = DateTime.UtcNow
            };
            
            var result = await _userRepository.Create(newUser);
            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Create user failed: {e}",e);
        }

        return false;
    }

    private async Task<bool> CheckExistedUser(string email)
    {
        var existing = await _userRepository.IsExistedByEmail(email);
        
        if(!existing)
        {
            Console.WriteLine($"User with email {email} already exited", email);
            return false;
        }

        return true;
    }
}