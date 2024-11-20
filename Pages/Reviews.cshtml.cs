using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using total_test_1.Models.Reviews;

namespace total_test_1.Pages
{
    public class ReviewsModel : PageModel
    {
        private readonly ReviewsContext _context;
        public ReviewsModel(ReviewsContext context)
        {
            _context = context;
        } 
        public List<Review> Reviews { get; set; } = new List<Review>();

        [BindProperty]
        public Review NewReview { get; set; } = new Review();

        [BindProperty]
        public Reviewer NewReviewer { get; set; } = new Reviewer();

        public DateOnly NewDateOnly { get; set; }
        

        public void OnGet(string? rate)
        { 
            Reviews = _context.Reviews 
                .Include(r => r.Reviewer)
                .Include(r => r.Rating)
                .ToList();
                
        } 

        public IActionResult OnPostAddReview()
        {
            if (ModelState.IsValid)
            {


                DateTime todaysDate = DateTime.Now;
                NewDateOnly = DateOnly.FromDateTime(todaysDate);
                

                NewReview.Reviewer = NewReviewer;
                //NewReview.RatingId = NewRating.RatingId;
                NewReview.DateCreated = NewDateOnly;

                

                _context.Reviews.Add(NewReview);
                _context.SaveChanges();


                return RedirectToPage("/Reviews");
            } 

            return Page();
        }
    }
}
