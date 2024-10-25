using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace total_test_1.Pages
{
    public class LoginModel : PageModel
    {
        public void OnGet()
        {
        }
        public static string loginClicked()
        {

            return "the button worked!";
        }
    }
}
