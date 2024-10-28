using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace total_test_1.Pages
{
    public class CollisionRepairModel : PageModel
    {
        private readonly ILogger<CollisionRepairModel> _logger;

        public CollisionRepairModel(ILogger<CollisionRepairModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }

}
