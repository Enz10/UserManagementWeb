using UserManagementWeb.Dtos.Users;

namespace UserManagementWeb.Dtos.User;

public class CreateUsersDto
{
    public IEnumerable<CreateUserDto> Users { get; set; }
}
