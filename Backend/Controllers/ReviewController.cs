using Backend.Context;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ReviewsController(AppDbContext context)
        {
            _context = context;
        }
   
        [HttpGet]
        public ActionResult<List<Review>> GetReviews()
        {
            return _context.Reviews.ToList();
        }
      
        [HttpPost]
        public ActionResult<Review> CreateReview(Review review)
        {
            _context.Reviews.Add(review);
            _context.SaveChanges();
            return review;
        }
    }

}

