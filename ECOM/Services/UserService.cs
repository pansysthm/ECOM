using ECOM.Entities;
using ECOM.Helper;
using ECOM.Models;
using ECOM.Queries;
using ECOM.Repositories;
using Microsoft.AspNetCore.Identity.Data;

namespace ECOM.Services;

public class UserService : IUserService
{
    private readonly IUserCommand _userCommand;
    private readonly IUserQuery _userQuery;
    private readonly IEncryptPasswordHelper _encryptPasswordHelper;
    private readonly IUserValidation _userValidation;

    public UserService(IUserCommand userCommand, IEncryptPasswordHelper encryptPasswordHelper, IUserValidation userValidation, IUserQuery userQuery)
    {
        _userCommand = userCommand;
        _encryptPasswordHelper = encryptPasswordHelper;
        _userValidation = userValidation;
        _userQuery = userQuery;
    }

    public async Task<bool> CreateAsync(CreateUserRequest request)
    {
        try
        {
            var isUserExisted = await CheckExistedUserAsync(request.Email);

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
            
            var result = await _userCommand.CreateAsync(newUser);
            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Create user failed: {e}",e);
        }

        return false;
    }

    public async Task<bool> ValidateUserAsync(LoginRequest request)
    {
        var user = await _userQuery.GetByEmailAsync(request.Email);
        return user != null;
    }

    public async Task<IEnumerable<UserDto>> GetAllAsync()
    {
        return await _userQuery.GetAllAsync();
    }

    private async Task<bool> CheckExistedUserAsync(string email)
    {
        var existing = await _userCommand.IsExistedByEmailAsync(email);

        if (existing) return true;
        Console.WriteLine($"User with email {email} already exited", email);
        return false;
    }
}