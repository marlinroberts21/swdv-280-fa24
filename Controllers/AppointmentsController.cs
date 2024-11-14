using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using total_test_1.Models.Schedule;

namespace total_test_1.Controllers
{
    public class AppointmentsController : Controller
    {

        private ScheduleContext _context;

        public AppointmentsController(ScheduleContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public IActionResult AddApointment(Appointment appointment)
        {
            ViewBag.Categories = _context.Categories.ToList();

            if (ModelState.IsValid)
            {
                return RedirectToAction("Confirmation", appointment);
            }
            else
            {
                return View(appointment);
            }
        }

        [HttpGet]
        public IActionResult Confirmation(Appointment appointment)
        {
            return View("Confirmation", appointment);
        }

    }
}