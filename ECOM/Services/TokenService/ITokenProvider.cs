using ECOM.Models;
using Microsoft.AspNetCore.Identity.Data;

namespace ECOM.Services.TokenService;

public interface ITokenProvider
{
    AuthResponseModel GenerateToken(LoginRequest loginUser);
    AuthResponseModel RenewToken();
    bool IsAuth();
}