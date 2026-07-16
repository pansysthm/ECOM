using System.ComponentModel.DataAnnotations;

namespace ECOM.Models;

public class CreateUserRequest
{
    [Required] 
    public string Email { get; set; } = null!;
    [Required] 
    public string Password { get; set; } = null!;
    [Required]
    public string FullName { get; set; } = null!;
}