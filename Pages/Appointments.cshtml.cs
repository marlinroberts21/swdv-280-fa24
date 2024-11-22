
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

        [BindProperty(SupportsGet = true)]
        public DateTime SelectedDate { get; set; }

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
        public string PhoneNumber { get; set; }

        public List<SelectListItem> CategoryOptions { get; set; }
        public List<SelectListItem> TimeOptions { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (SelectedDate == default) // If not already set via query string or binding
            {
                SelectedDate = DateTime.Today;
            }

            CategoryOptions = await _context.Categories.Select(c => new SelectListItem
            {
                Value = c.CategoryId.ToString(),
                Text = c.Category1
            })
            .ToListAsync();

            TimeOptions = await GetAvailableTimes(DateOnly.FromDateTime(SelectedDate));

            return Page();

        }

        public async Task<IActionResult> OnGetFetchTimesAsync(DateTime selectedDate)
        {
            // Load available times based on selected date only (no category filtering)
            var availableTimes = await GetAvailableTimes(DateOnly.FromDateTime(selectedDate));

            if (!availableTimes.Any())
            {
                return new JsonResult(new { message = "No times availabe for selected date.", times = new List<Object>() });
            }

            var result = availableTimes.Select(t => new
            {
                value = t.Value,
                text = t.Text
            }).ToList();

            return new JsonResult(new { message = string.Empty, times = result });
        }

        public async Task<IActionResult> OnPostSubmitAsync()
        {
            if (SelectedDate.Date < DateTime.Now.Date)
            {
                ModelState.AddModelError("SelectedDate", "You cannot select a past date.");
            }

            // Ensure the time is still available (double-check for any possible race conditions)
            var isTimeAvailable = await _context.Times
                .AnyAsync(t => t.TimeId == SelectedTimeId &&
                       !_context.Appointments.Any(a => a.Date == DateOnly.FromDateTime(SelectedDate) && a.TimeId == SelectedTimeId));

            if (!isTimeAvailable)
            {
                ModelState.AddModelError("", "The selected time slot is no longer available. Please choose another time.");
                TimeOptions = await GetAvailableTimes(DateOnly.FromDateTime(SelectedDate));
                CategoryOptions = await _context.Categories.Select(c => new SelectListItem
                {
                    Value = c.CategoryId.ToString(),
                    Text = c.Category1
                }).ToListAsync();
                return Page();
            }

            if (ModelState.IsValid)
            {
                // Create the new appointment
                var appointment = new Appointment
                { 
                    Date = DateOnly.FromDateTime(SelectedDate),
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

                _context.Appointments.Add(appointment);
                await _context.SaveChangesAsync();

                return RedirectToPage("Confirmation");

            }
            else
            {
                CategoryOptions = await _context.Categories.Select(c => new SelectListItem
                {
                    Value = c.CategoryId.ToString(),
                    Text = c.Category1
                })
                .ToListAsync();

                TimeOptions = await GetAvailableTimes(DateOnly.FromDateTime(SelectedDate));

                return Page();
            }
        }

        private async Task<List<SelectListItem>> GetAvailableTimes(DateOnly date)
        {
            var bookedTimes = await _context.Appointments
            .Where(a => a.Date == date)
            .Select(a => a.TimeId)
            .ToListAsync();

            return await _context.Times
                .Where(t => !bookedTimes.Contains(t.TimeId))
                .Select(t => new SelectListItem
                {
                    Value = t.TimeId.ToString(),
                    Text = t.Time1.ToString("H:mm")
                })
                .ToListAsync();
        }


    }
}