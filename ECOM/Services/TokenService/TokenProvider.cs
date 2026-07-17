using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ECOM.Entities;
using ECOM.Models;
using Microsoft.AspNetCore.Identity.Data;

namespace ECOM.Services.TokenService;

public class TokenProvider(IConfiguration config, IHttpContextAccessor httpContextAccessor) : ITokenProvider
{
    public AuthResponseModel GenerateToken(LoginRequest loginUser)
    {
        var expiresInHours = double.Parse(config["JWT:ExpiresInHours"]!);
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Key"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var tokenHandler = new JwtSecurityTokenHandler();
        var now = DateTime.UtcNow;

        var accessToken = new JwtSecurityToken(
            issuer: "ECOM",
            audience: "ECOM",
            claims: [new Claim(ClaimTypes.Email, loginUser.Email)],
            expires: now.AddDays(7),
            signingCredentials: creds
        );

        var refreshToken = new JwtSecurityToken(
            issuer: "ECOM",
            audience: "ECOM",
            claims: [new Claim(ClaimTypes.Email, loginUser.Email)],
            expires: now.AddDays(7),
            signingCredentials: creds
        );

        httpContextAccessor.HttpContext?.Response.Cookies.Append("refreshToken", tokenHandler.WriteToken(refreshToken), new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.Strict
        });

        return new AuthResponseModel
        {
            AccessToken = tokenHandler.WriteToken(accessToken),
            RefreshToken = tokenHandler.WriteToken(refreshToken),
            ExpiresIn = expiresInHours,
            User = new AuthUser
            {
                   Email = loginUser.Email
            }
        };
    }

    public AuthResponseModel RenewToken()
    {
        var token = httpContextAccessor.HttpContext?.Request.Cookies["refreshToken"];
        if (string.IsNullOrEmpty(token)) throw new UnauthorizedAccessException("Refresh token missing.");
        var handler = new JwtSecurityTokenHandler();
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Key"]!));

        var principal = handler.ValidateToken(token, new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = key,
            ValidateIssuer = false,
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero
        }, out _);

        var email = principal.FindFirst(ClaimTypes.Email)?.Value;
        
        var accessToken = new JwtSecurityToken(
            issuer: "ECOM", audience: "ECOM",
            claims: [new Claim(ClaimTypes.Email, email!)],
            expires: DateTime.UtcNow.AddHours(double.Parse(config["JWT:ExpiresInHours"]!)),
            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
        );

        return new AuthResponseModel
        {
            AccessToken = handler.WriteToken(accessToken),
            RefreshToken = token!,
            ExpiresIn = double.Parse(config["JWT:ExpiresInHours"]!),
            User = new AuthUser { Email = email! }
        };
    }



    public bool IsAuth()
    {
        return httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false;
    }
}