using Microsoft.AspNetCore.Mvc;
using total_test_1.Models.Admin;
using total_test_1.Models.Schedule;
using total_test_1.Pages;
using total_test_1.Services;

namespace total_test_1.Controllers
{
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
        public IActionResult Schedule()
        {
            //AppointmentDisplay appointmentViewer = new AppointmentDisplay();
            //appointmentViewer.Customer = context.Customers;
            //appointmentViewer.Appointment = context.Appointments;
            //appointmentViewer.Time = context.Times;

            List<AppointmentDisplay> appointmentViewer = new List<AppointmentDisplay>();
            int i = 0;
			string? firstName = null;
			string? lastName = null;
			TimeOnly? theTime = null;
			foreach (Customer customer in context.Customers)
            {
				int j = 0;
                foreach(Appointment appointment in context.Appointments)
                {
                    foreach (Time time in context.Times)
                    {

                
                    if (appointment.CustomerId == customer.CustomerId && appointment.TimeId == time.TimeId)
                    {
                        firstName = customer.FirstName;
                        lastName = customer.LastName;
                        theTime = time.Time1;
                    }
                    int k = 0;
                                            
                    k++;
                    }
                j++;
                }
            i++;
                    appointmentViewer.Add(new AppointmentDisplay(theTime, firstName, lastName));
                firstName = null;
                lastName = null;
                theTime = null;
            }
            //foreach (Appointment appointment in context.Appointments)
            //    foreach (Customer customer in context.Customers)
                    
            //if (appointment.CustomerId == customer.CustomerId)
            //{
            //            appointmentViewer[i].FirstName = customer.FirstName;
            //            appointmentViewer
            //}

            ViewBag.appointmentViewer = appointmentViewer;
            return View("../Admin");
        }
    }
}
