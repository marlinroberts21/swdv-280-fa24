using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using total_test_1.Models;
using total_test_1.Services;

namespace total_test_1.Pages
{
    [Authorize]
    public class AdminModel : PageModel
    {
        private readonly ILogger<AdminModel> _logger;
        //private readonly ScheduleDbContext _context;

        public AdminModel(ILogger<AdminModel> logger)/*(ScheduleDbContext context)*/
        {
            _logger = logger;
            //_context = context;
        }
        //public List<Customer> Customers { get; set; }
        public void OnGet()
        {
            //this.Customers = _context.GetCustomers().ToList();
        }
        //public void OnPost()
        //{
        //    Customers = _context.GetCustomers().ToList();
        //}
        
        //[HttpGet]
        //public async Task<ActionResult<List<Customer>>> GetCustomers()
        //{
        //    var result = await _context.Customers.ToListAsync();
        //    return result;
        //}
        //public IActionResult Load()
        //{
        //    Customer customer = new Customer();
        //    ViewBag
        //}

        //add a method that allows radio buttons to work as expected. Listviews don't play nice with radio buttons.
    }
}
