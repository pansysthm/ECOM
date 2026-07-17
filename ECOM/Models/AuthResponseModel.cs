namespace ECOM.Models;

public class AuthResponseModel
{
    public string AccessToken { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;
    public double ExpiresIn { get; set; }
    public AuthUser User { get; set; } = new AuthUser();
}

public class AuthUser
{
    public string Email { get; set; } = string.Empty;
}