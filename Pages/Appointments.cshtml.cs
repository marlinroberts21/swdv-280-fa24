
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using total_test_1.Models.Schedule;


namespace total_test_1.Pages
{
    public class AppointmentsModel : PageModel
    {
        private readonly ILogger<AppointmentsModel> _logger;
        public AppointmentsModel(ILogger<AppointmentsModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {

        }
    }
}