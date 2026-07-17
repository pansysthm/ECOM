using ECOM.Services;
using ECOM.Services.TokenService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace ECOM.Controllers;

[Route("auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly ITokenProvider _tokenProvider;

    public AuthController(IUserService userService, ITokenProvider tokenProvider)
    {
        _userService = userService;
        _tokenProvider = tokenProvider;
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var isValidated = await _userService.ValidateUserAsync(request);

        if (!isValidated)
        {
            return Unauthorized();
        }

        var result = _tokenProvider.GenerateToken(request);

        return Ok(result);
    }

    [HttpGet("renew-token")]
    [Authorize]
    public Task<IActionResult> RefreshToken()
    {
        try
        {
            var result = _tokenProvider.RenewToken();
            return Task.FromResult<IActionResult>(Ok(result));
        }
        catch (Exception exception)
        {
            return Task.FromException<IActionResult>(exception);
        }
    }
}