namespace UserManagementWeb.Services;

public interface IAuthService
{
    Task<string> LoginAsync(LoginDto loginDto);
}

public class LoginDto
{
    public string Email { get; set; }
    public string Password { get; set; }
}