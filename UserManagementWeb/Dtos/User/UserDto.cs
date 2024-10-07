namespace UserManagementWeb.Dtos.User;

public class UserDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string Country { get; set; }
    public string Province { get; set; }
    public string City { get; set; }
    public string Email { get; set; }
    public string? Password { get; set; }
    public string? PasswordHash { get; set; }
    public DateTime CreatedAt { get; set; }
}
