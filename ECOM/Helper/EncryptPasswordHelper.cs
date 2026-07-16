namespace ECOM.Helper;

public class EncryptPasswordHelper : IEncryptPasswordHelper
{
    public string Encrypt(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }
}