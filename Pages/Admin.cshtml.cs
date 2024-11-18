using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using total_test_1.Models.Schedule;

namespace total_test_1.Pages
{
    [Authorize]
    public class AdminModel : PageModel
    {
        private readonly ILogger<AdminModel> _logger;


        public AdminModel(ILogger<AdminModel> logger)
        {
            _logger = logger;
        }
        public RedirectToActionResult OnGet()
        {
            return RedirectToAction("Schedule", "Admin");
        }

    }
}
