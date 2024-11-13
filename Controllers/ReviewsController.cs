using Microsoft.AspNetCore.Mvc;
using total_test_1.Models;
using total_test_1.Models.Reviews;

namespace total_test_1.Controllers
{
    public class ReviewsController : Controller
    { 
        private ReviewsContext context;

        public ReviewsController(ReviewsContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            return View();
        }

        // adds reviews
        [HttpPost]
        public IActionResult Add(string firstName, string lastName, string reviewText)
        { 
            if(ModelState.IsValid)
            {
                var reviewer = new Reviewer
                {
                    FirstName = firstName,
                    LastName = lastName
                };

                context.Reviewers.Add(reviewer);
                context.SaveChanges();

                var review = new Review
                {
                    ReviewerId = reviewer.ReviewerId,
                    ReviewText = reviewText
                };

                context.Reviews.Add(review);
                context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();

        }

        
    }
}
