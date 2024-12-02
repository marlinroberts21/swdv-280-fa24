using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using total_test_1.Models.Schedule;
using total_test_1.Pages;

namespace total_test_1.Controllers
{
    public class AppointmentsController : Controller
    {

        private ScheduleContext _context;

        public AppointmentsController(ScheduleContext context)
        {
            _context = context;
        }

    }
}