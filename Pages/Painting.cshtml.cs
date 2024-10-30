
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace total_test_1.Pages
{
    public class PaintingModel : PageModel
    {
        private readonly ILogger<PaintingModel> _logger;

        public PaintingModel(ILogger<PaintingModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }

}



