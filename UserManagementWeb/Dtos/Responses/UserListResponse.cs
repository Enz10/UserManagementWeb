using UserManagementWeb.Dtos.User;

namespace UserManagementWeb.Dtos.Responses;

public class UserListResponse
{
    public List<UserDto> Items { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
    public int TotalCount { get; set; }
}
