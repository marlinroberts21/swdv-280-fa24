using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
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
                ViewBag.selectedDate = DateTime.Today.ToString("yyyy-MM-dd");
			}
            else 
            {
				dateOnly = DateOnly.Parse(selectedDate);
                ViewBag.selectedDate = selectedDate;
				Response.Cookies.Append("selectedDate", DateOnly.Parse(selectedDate).ToString(), new CookieOptions { Expires = DateTime.Now.AddDays(1) });
			}
			var appointmentViewer = (
                                        from customer in context.Customers
                                        join appointment in context.Appointments
                                            on customer.CustomerId equals appointment.CustomerId
                                        join time in context.Times
                                            on appointment.TimeId equals time.TimeId
                                        where appointment.Date == dateOnly
                                        select new AppointmentDisplay(appointment.AppointmentId, time.Time1, customer.FirstName, customer.LastName)
                                    );

                ViewBag.appointmentViewer = appointmentViewer;
                
                
			
			return View("../Admin");
        }
        public IActionResult Select(string id)
        {
            string date2 = Request.Cookies["selectedDate"];
			

			DateOnly dateOnly = DateOnly.Parse(date2);

			int intId = Int32.Parse(id);
            var expandedAppointment = (
                from customer in context.Customers
                join appointment in context.Appointments
                    on customer.CustomerId equals appointment.CustomerId
                join time in context.Times
                    on appointment.TimeId equals time.TimeId
                join category in context.Categories
                    on appointment.CategoryId equals category.CategoryId
                where appointment.AppointmentId == intId
                select new FullDisplay(appointment.AppointmentId, appointment.Date, time.Time1, customer.FirstName, customer.LastName, category.Category1, customer.Email, customer.PhoneNumber)
                );
            foreach (FullDisplay fullDisplay in expandedAppointment)
            {
				ViewBag.fullDisplay = fullDisplay;
			}
            
			var appointmentViewer = (
							from customer in context.Customers
							join appointment in context.Appointments
								on customer.CustomerId equals appointment.CustomerId
							join time in context.Times
								on appointment.TimeId equals time.TimeId
							where appointment.Date == dateOnly
							select new AppointmentDisplay(appointment.AppointmentId, time.Time1, customer.FirstName, customer.LastName)
						);
            ViewBag.appointmentViewer = appointmentViewer;
            string datestring = Request.Cookies["selectedDate"];
            DateTime date;
            if (DateTime.TryParse(datestring, out date))
            {
                string formattedDate = date.ToString("yyyy-MM-dd");
                ViewBag.selectedDate = formattedDate;
            }
			

			return View("../Admin");
        }
    }
}
