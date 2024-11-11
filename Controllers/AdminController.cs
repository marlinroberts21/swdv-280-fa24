using Microsoft.AspNetCore.Mvc;

namespace total_test_1.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
