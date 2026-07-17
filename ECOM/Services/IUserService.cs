using ECOM.Models;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace ECOM.Services;

public interface IUserService
{
    Task<bool> CreateAsync(CreateUserRequest request);
    Task<bool> ValidateUserAsync(LoginRequest request);
    Task<IEnumerable<UserDto>> GetAllAsync();
}