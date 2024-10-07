using System.ComponentModel.DataAnnotations;

namespace UserManagementWeb.Dtos.Users;

public class CreateUserDto
{
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    [Range(1, 120)]
    public int Age { get; set; }
    [Required]
    public string Country { get; set; }
    public string Province { get; set; }
    public string City { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
