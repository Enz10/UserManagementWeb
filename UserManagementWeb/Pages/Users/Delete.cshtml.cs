using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserManagementWeb.Dtos.User;
using UserManagementWeb.Interfaces;

namespace UserManagementWeb.Pages.Users
{
    public class DeleteModel : PageModel
    {
        private readonly IUserService _userService;

        public DeleteModel(IUserService userService) => _userService = userService;

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

        public async Task<IActionResult> OnPostAsync(int id)
        {
            await _userService.DeleteUserAsync(id);

            return RedirectToPage("./Index");
        }
    }
}