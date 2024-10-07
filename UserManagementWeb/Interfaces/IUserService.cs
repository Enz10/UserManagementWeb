using UserManagementWeb.Dtos.Responses;
using UserManagementWeb.Dtos.User;

namespace UserManagementWeb.Interfaces;

public interface IUserService
{
    Task<UserListResponse> GetUsersAsync(int page, int pageSize, int? age, string country);
    Task<UserDto> GetUserByIdAsync(int id);
    Task<UserDto> CreateUserAsync(UserDto user);
    Task<IEnumerable<UserDto>> CreateUsersAsync(CreateUsersDto command);
    Task<UserDto> UpdateUserAsync(int id, UserDto user);
    Task DeleteUserAsync(int id);
}
