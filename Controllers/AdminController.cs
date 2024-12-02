using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
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
				Response.Cookies.Append("selectedDate", DateOnly.Parse(ViewBag.selectedDate).ToString(), new CookieOptions { Expires = DateTime.Now.AddDays(1) });
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
            if (id != null)
            {
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

		public IActionResult Delete(string id)
		{
			string date2 = Request.Cookies["selectedDate"];


			DateOnly dateOnly = DateOnly.Parse(date2);
			if (id != null)
			{
				int intId = Int32.Parse(id);
				var selectCustomerId = (
					from appointment in context.Appointments
					where appointment.AppointmentId == intId
					select (appointment.CustomerId)
				);

				int customerId = 0;
				foreach (var customer in selectCustomerId) {
					customerId = Int32.Parse(customer.ToString());
				}

				var test2 = new Appointment();
				foreach (var test in context.Appointments.Where(x => x.AppointmentId == intId)) {
					test2 = test;
				}

				var removeCustomer = new Customer();
				foreach (var customerRemover in context.Customers.Where(x => x.CustomerId == customerId)) {
					removeCustomer = customerRemover;
				}
				context.Appointments.Remove(test2);
				context.Customers.Remove(removeCustomer);
				context.SaveChanges();
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
