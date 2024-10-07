using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserManagementWeb.Dtos.User;
using UserManagementWeb.Interfaces;

namespace UserManagementWeb.Pages.Users;

public class EditModel : PageModel
{
    private readonly IUserService _userService;

    public EditModel(IUserService userService) => _userService = userService;

    [BindProperty]
    public UserDto User { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        User = await _userService.GetUserByIdAsync(id);

        if (User == null)
        {
            return NotFound();
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var error in errors)
            {
                ModelState.AddModelError(string.Empty, error.ErrorMessage);
            }
            return Page();
        }

        var existingUser = await _userService.GetUserByIdAsync(User.Id);
        if (existingUser == null)
        {
            return NotFound();
        }

        existingUser.FirstName = User.FirstName;
        existingUser.LastName = User.LastName;
        existingUser.Age = User.Age;
        existingUser.Country = User.Country;
        existingUser.Province = User.Province;
        existingUser.City = User.City;
        existingUser.Email = User.Email;

        await _userService.UpdateUserAsync(existingUser.Id, existingUser);

        return RedirectToPage("./Index");
    }
}