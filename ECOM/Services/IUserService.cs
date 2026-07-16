using ECOM.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECOM.Services;

public interface IUserService
{
    Task<bool> Create(CreateUserRequest request);
}