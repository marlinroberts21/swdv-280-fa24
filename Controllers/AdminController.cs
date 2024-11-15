using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using total_test_1.Models.Admin;
using total_test_1.Models.Schedule;
using total_test_1.Pages;
using total_test_1.Services;

namespace total_test_1.Controllers
{
	[Authorize]
	public class AdminController : Controller
    {

        private ScheduleContext context;
        public AdminController(ScheduleContext ctx)
        {
            context = ctx;
        }
        public IActionResult Index()
        {
            return RedirectToAction("Schedule");
        }
        public IActionResult Schedule(string? selectedDate)
        {
            DateOnly dateOnly;
            if (selectedDate == null)
            {
                dateOnly = DateOnly.Parse(DateTime.Today.ToString("MM/dd/yyyy"));
                ViewBag.s = DateTime.Today.ToString("yyyy-MM-dd");
			}
            else 
            {
				dateOnly = DateOnly.Parse(selectedDate);
                ViewBag.s = selectedDate;
			}
			var appointmentViewer = (
                                            from customer in context.Customers
                                            join appointment in context.Appointments
                                                on customer.CustomerId equals appointment.CustomerId
                                            join time in context.Times
                                                on appointment.TimeId equals time.TimeId
                                            where appointment.Date == dateOnly
                                            select new AppointmentDisplay(time.Time1, customer.FirstName, customer.LastName)
                                        );
           
                ViewBag.appointmentViewer = appointmentViewer;
                
			
			return View("../Admin");
        }
    }
}
