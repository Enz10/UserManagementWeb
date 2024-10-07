using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using UserManagementWeb.Services;

namespace UserManagementWeb.Pages.Users;

public class CreateModel : PageModel
{
    private readonly IUserService _userService;

    public CreateModel(IUserService userService)
    {
        _userService = userService;
    }

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