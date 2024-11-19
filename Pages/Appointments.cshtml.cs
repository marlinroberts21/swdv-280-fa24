
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using total_test_1.Models.Schedule;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;



namespace total_test_1.Pages
{
    public class AppointmentsModel : PageModel
    {

        private ScheduleContext _context;

        public Appointment appointment = new Appointment();

        public AppointmentsModel(ScheduleContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DateOnly SelectedDate { get; set; }

        [BindProperty]
        public int SelectedTimeId { get; set; }

        [BindProperty]
        public int CategoryId { get; set; }

        [BindProperty]
        public string FirstName { get; set; }

        [BindProperty]
        public string LastName { get; set; }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public int PhoneNumber { get; set; }

        public List<SelectListItem> CategoryOptions { get; set; }
        public List<SelectListItem> TimeOptions { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            CategoryOptions = await _context.Categories.Select(c => new SelectListItem
            {
                Value = c.CategoryId.ToString(),
                Text = c.Category1
            })
            .ToListAsync();

            TimeOptions = await GetAvailableTimes(SelectedDate);

            return Page();

        }

        public async Task<IActionResult> OnPostFetchTimesAsync()
        {
            // Load available times based on selected date only (no category filtering)
            TimeOptions = await GetAvailableTimes(SelectedDate);
            CategoryOptions = await _context.Categories.Select(c => new SelectListItem
            {
                Value = c.CategoryId.ToString(),
                Text = c.Category1
            })
            .ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostSubmitAsync()
        {
            //// Ensure the time is still available (double-check for any possible race conditions)
            //var isAlreadyBooked = await _context.Appointments
            //    .AnyAsync(a => a.Date == SelectedDate && a.TimeId == SelectedTimeId);

            //if (isAlreadyBooked)
            //{
            //    ModelState.AddModelError("", "The selected time slot is no longer available. Please choose another time.");
            //    return Page();
            //}

            SelectedTimeId = 1;

            // Create the new appointment
            var appointment = new Appointment
            { 
                Date = SelectedDate,
                TimeId = SelectedTimeId,
                CategoryId = CategoryId,
                Customer = new Customer
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    Email = Email,
                    PhoneNumber = PhoneNumber
                }
            };

            appointment.Time = await _context.Times.FindAsync(SelectedTimeId);
            appointment.Category = await _context.Categories.FindAsync(CategoryId);

            TempData["Appointment"] = JsonSerializer.Serialize(appointment);

            return RedirectToPage("Confirmation");
        }

        private async Task<List<SelectListItem>> GetAvailableTimes(DateOnly date)
        {
            var bookedTimes = await _context.Appointments
            .Where(a => a.Date == date)
            .Select(a => a.TimeId)
            .ToListAsync();

            return await _context.Appointments
            .Where(a => a.Date == date && !bookedTimes.Contains(a.TimeId))
            .Select(a => new SelectListItem
            {
                Value = a.TimeId.ToString(),
                Text = a.Time.Time1.ToString("H:mm")
            })
            .ToListAsync();
        }
    }
}