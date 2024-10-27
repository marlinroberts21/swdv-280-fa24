using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace total_test_1.Pages
{
    [Authorize]
    public class tempAdminModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
