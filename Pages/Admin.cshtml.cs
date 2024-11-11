using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using total_test_1.Models;
using total_test_1.Services;

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
        public void OnGet()
        {
        }

    }
}
