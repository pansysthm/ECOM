using System.Text.RegularExpressions;
using ECOM.Models;

namespace ECOM.Helper;

public class UserValidation : IUserValidation
{
    private readonly Regex _emailRegex = new(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$", RegexOptions.Compiled);
    private readonly Regex _passwordRegex = new(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{7,}$", RegexOptions.Compiled);
    
    public bool Validation(CreateUserRequest user)
    {
        if (string.IsNullOrWhiteSpace(user.Email) || string.IsNullOrWhiteSpace(user.FullName) || string.IsNullOrWhiteSpace(user.Password))
        {
            Console.WriteLine("User info cannot be empty");
            return false;
        }

        if (!_emailRegex.IsMatch(user.Email))
        {
            Console.WriteLine("Email is not valid");
            return false;
        }
        
        if (!_passwordRegex.IsMatch(user.Password))
        {
            Console.WriteLine("Password is not valid");
            return false;
        }
        
        return true;
    }
}