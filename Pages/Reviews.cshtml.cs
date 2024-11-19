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

        //public Rating NewRating { get; set; } = new Rating();
        public void OnGet(string? rate)
        { 
            Reviews = _context.Reviews 
                .Include(r => r.Reviewer)
                //.Include(r => r.Rating)
                .ToList();
            ViewData["thiss"] = null;
            
        } 

        public IActionResult OnPostAddReview()
        {
            if (ModelState.IsValid)
            {
                _context.Reviewers.Add(NewReviewer);
                _context.SaveChanges();

                // adds rating
                //_context.Ratings.Add(NewRating);
                //_context.SaveChanges();

                NewReview.ReviewerId = NewReviewer.ReviewerId;

                if (ViewData["thiss"] != null)
                {
                    NewReview.RatingId = Int32.Parse(ViewData["thiss"].ToString());
                }
                else
                {
                    NewReview.RatingId = 1;
                }
                //NewReview.RatingId = NewReview.RatingId;

                _context.Reviews.Add(NewReview);
                _context.SaveChanges();

                return RedirectToPage("/Reviews");
            } 

            return Page();
        }
    }
}
