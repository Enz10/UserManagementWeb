using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserManagementWeb.Services;
using Microsoft.Extensions.Logging;

namespace UserManagementWeb.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(IUserService userService, ILogger<IndexModel> logger)
        {
            _userService = userService;
            _logger = logger;
        }

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
            _logger.LogInformation($"Query string: {HttpContext.Request.QueryString}");
            _logger.LogInformation($"Received page parameter: {page}");

            CurrentPage = page ?? 1;

            _logger.LogInformation($"Fetching page {CurrentPage}");

            var result = await _userService.GetUsersAsync(CurrentPage, PageSize, Age, Country);
            Users = result.Items;
            TotalPages = result.TotalPages;
            TotalCount = result.TotalCount;

            _logger.LogInformation($"Received {Users.Count()} users. Total pages: {TotalPages}, Total count: {TotalCount}");
            _logger.LogInformation($"Final CurrentPage: {CurrentPage}");
        }
    }
}