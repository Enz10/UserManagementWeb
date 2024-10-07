using System.Collections.Generic;
using System.Threading.Tasks;

namespace UserManagementWeb.Services;

public interface IUserService
{
    Task<UserListResponse> GetUsersAsync(int page, int pageSize, int? age, string country);
    Task<UserDto> GetUserByIdAsync(int id);
    Task<UserDto> CreateUserAsync(UserDto user);
    Task<IEnumerable<UserDto>> CreateUsersAsync(IEnumerable<UserDto> users);
    Task<UserDto> UpdateUserAsync(int id, UserDto user);
    Task DeleteUserAsync(int id);
}

public class UserListResponse
{
    public List<UserDto> Items { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
    public int TotalCount { get; set; }
}

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