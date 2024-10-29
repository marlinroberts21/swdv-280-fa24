using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace total_test_1.Pages
{
    public class FormsModel : PageModel
    {
        private readonly ILogger<FormsModel> _logger;

        public FormsModel(ILogger<FormsModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }

}
