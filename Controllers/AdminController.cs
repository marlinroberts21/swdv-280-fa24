using Microsoft.AspNetCore.Mvc;
using total_test_1.Models.Schedule;
using total_test_1.Pages;

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
            List<Customer> customer = new List<Customer>();
            customer = context.Customers.ToList();
            string test = "hello";
            return View(customer);
        }
    }
}
