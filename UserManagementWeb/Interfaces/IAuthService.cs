using UserManagementWeb.Dtos.Login;

namespace UserManagementWeb.Interfaces;

public interface IAuthService
{
    Task<string> LoginAsync(LoginDto loginDto);
}