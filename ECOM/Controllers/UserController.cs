using ECOM.Models;
using ECOM.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECOM.Controllers;

[Route("user")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateUserRequest request)
    {
        var result = await _userService.Create(request);
        return Ok(result);
    }
}