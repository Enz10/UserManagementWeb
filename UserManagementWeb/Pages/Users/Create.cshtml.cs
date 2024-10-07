using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserManagementWeb.Dtos.User;
using UserManagementWeb.Dtos.Users;
using UserManagementWeb.Interfaces;

namespace UserManagementWeb.Pages.Users;

public class CreateModel : PageModel
{
    private readonly IUserService _userService;

    public CreateModel(IUserService userService) => _userService = userService;

    [BindProperty]
    public CreateUserDto User { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var userDto = new UserDto
        {
            FirstName = User.FirstName,
            LastName = User.LastName,
            Age = User.Age,
            Country = User.Country,
            Province = User.Province,
            City = User.City,
            Email = User.Email,
            Password = User.Password
        };

        await _userService.CreateUserAsync(userDto);

        return RedirectToPage("./Index");
    }
}