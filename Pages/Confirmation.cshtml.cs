
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

namespace total_test_1.Pages
{
    public class ConfirmationModel : PageModel
    {
        private readonly ILogger<ConfirmationModel> _logger;

        public ConfirmationModel(ILogger<ConfirmationModel> logger)
        {
            _logger = logger;
        }

        [Required]
        public string AppointmentDate { get; set; }

        [Required]
        public string AppointmentTime { get; set; }

        [Required]
        public string ServiceType { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        public void OnGet(string appointmentDate, string appointmentTime, string serviceType, string firstName, string lastName, string email, string phone)
        {
            AppointmentDate = appointmentDate;
            AppointmentTime = appointmentTime;
            ServiceType = serviceType;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;

            _logger.LogInformation("Appointment confirmed for {FirstName} {LastName} on {AppointmentDate} at {AppointmentTime}", FirstName, LastName, AppointmentDate, AppointmentTime);
        }
        
        public void OnGet()
        {
        }
    }
}
