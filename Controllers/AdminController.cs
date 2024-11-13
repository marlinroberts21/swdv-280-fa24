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
            foreach(Customer customer in context.Customers)
            {
                foreach(Appointment appointment in context.Appointments)
                {

                
                    if (appointment.CustomerId == customer.CustomerId)
                    {
                        appointmentViewer.Add()
                        appointmentViewer[i].FirstName = customer.FirstName;
                        appointmentViewer[i].LastName = customer.LastName;
                    }
                    i++;
                }
            }
            //foreach (Appointment appointment in context.Appointments)
            //    foreach (Customer customer in context.Customers)
                    
            //if (appointment.CustomerId == customer.CustomerId)
            //{
            //            appointmentViewer[i].FirstName = customer.FirstName;
            //            appointmentViewer
            //}

            ViewBag.appointmentView = appointmentViewer;
            return View("../Admin");
        }
    }
}
