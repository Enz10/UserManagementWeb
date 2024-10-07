using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UserManagementWeb.Pages
{
    public class IndexModel : PageModel
    {
        public IndexModel()
        {}

        public IActionResult OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToPage("/Users/Index");
            }
            return RedirectToPage("/Login");
        }
    }
}