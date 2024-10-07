using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserManagementWeb.Dtos.User;
using UserManagementWeb.Dtos.Users;
using UserManagementWeb.Interfaces;

namespace UserManagementWeb.Pages.Users
{
    public class BulkCreateModel : PageModel
    {
        private readonly IUserService _userService;

        public BulkCreateModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public List<CreateUserDto> Users { get; set; } = new List<CreateUserDto>();

        public void OnGet()
        {
            Users.Add(new CreateUserDto());
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var command = new CreateUsersDto
            {
                Users = Users.Select(u => new CreateUserDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    Country = u.Country,
                    Province = u.Province,
                    City = u.City,
                    Email = u.Email,
                    Password = u.Password
                }).ToList()
            };

            try
            {
                await _userService.CreateUsersAsync(command);
                return RedirectToPage("./Index");
            }
            catch (HttpRequestException ex)
            {
                ModelState.AddModelError(string.Empty, $"Error creating users: {ex.Message}");
                return Page();
            }
        }
    }
}