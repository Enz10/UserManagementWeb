using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using UserManagementWeb.Dtos.User;
using UserManagementWeb.Interfaces;

namespace UserManagementWeb.Pages.Users
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IUserService _userService;

        public IndexModel(IUserService userService) => _userService = userService;

        public IEnumerable<UserDto> Users { get; set; } = new List<UserDto>();
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;

        [BindProperty(SupportsGet = true)]
        public int? Age { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Country { get; set; }

        public int PageSize { get; set; } = 10;

        public async Task OnGetAsync([FromQuery] int? page)
        {
            CurrentPage = page ?? 1;


            var result = await _userService.GetUsersAsync(CurrentPage, PageSize, Age, Country);
            Users = result.Items;
            TotalPages = result.TotalPages;
            TotalCount = result.TotalCount;
        }
    }
}