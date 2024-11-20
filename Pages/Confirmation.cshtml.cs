
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using total_test_1.Models.Schedule;
using System.Text.Json;
using Microsoft.Identity.Client;

namespace total_test_1.Pages
{
    public class ConfirmationModel : PageModel
    {
        private readonly ILogger<ConfirmationModel> _logger;

        public ConfirmationModel(ILogger<ConfirmationModel> logger)
        {
            _logger = logger;
        }


        public Appointment Appointment { get; set; }

        public void OnGet()
        {
            if (TempData.ContainsKey("Appointment"))
            {
                Appointment = JsonSerializer.Deserialize<Appointment>(TempData["Appointment"].ToString());
            }
            else
            {
                RedirectToPage("Appointments");
            }
        }
    }
}
