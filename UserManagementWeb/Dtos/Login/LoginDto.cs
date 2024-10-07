using System.ComponentModel.DataAnnotations;

namespace UserManagementWeb.Dtos.Login;

public class LoginDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
