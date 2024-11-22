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

        [BindProperty]
        public Rating NewRating { get; set; } = new Rating();

        public double AverageRating { get; private set; } = 0; // Average rating
        public DateOnly NewDateOnly { get; set; }
        

        public void OnGet(string? rate)
        { 
            Reviews = _context.Reviews 
                .Include(r => r.Reviewer)
                .Include(r => r.Rating)
                .ToList();

            // Calculate the average rating
            if (Reviews.Any())
            {
                AverageRating = Reviews
                    .Where(r => r.Rating != null) // Ensure ratings exist
                    .Average(r => r.Rating.Ratings);
            }
        }

        public IActionResult OnPostAddReview()
        {
            if (ModelState.IsValid)
            {
                // Save Reviewer
                _context.Reviewers.Add(NewReviewer);
                _context.SaveChanges();

                // Save Rating
                if (NewRating.Ratings >= 1 && NewRating.Ratings <= 5)
                {
                    _context.Ratings.Add(NewRating);
                    _context.SaveChanges();
                }
                else
                {
                    Console.WriteLine($"Invalid Rating Value: {NewRating.Ratings}.");
                    return Page();
                }

                // Save Review
                NewReview.ReviewerId = NewReviewer.ReviewerId;
                NewReview.RatingId = NewRating.RatingId;

                DateTime todaysDate = DateTime.Now;
                NewDateOnly = DateOnly.FromDateTime(todaysDate);
                

                NewReview.Reviewer = NewReviewer;
                NewReview.DateCreated = NewDateOnly;

                _context.Reviews.Add(NewReview);
                _context.SaveChanges();

                return RedirectToPage("/Reviews");
            }

            Console.WriteLine("ModelState is invalid.");
            return Page();
            
        }

    }
}
