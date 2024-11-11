using Microsoft.AspNetCore.Mvc;
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
        public string Index()
        {
            return "Test Index";
        }

        public string Test()
        {
            string name = "";

            foreach (Customer customer in context.Customers)
            {
                name = customer.FirstName;
            }
            return name;
        }
    }
}
