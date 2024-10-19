using Backend.Models;
using Backend.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewRepository _repository;

        public ReviewsController(IReviewRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetReviews()
        {
            var reviews = _repository.GetAll();
            return Ok(reviews);
        }

        [HttpPost]
        public IActionResult CreateReview([FromBody] Review review)
        {
            _repository.Add(review);
            if (_repository.SaveChanges())
            {
                return CreatedAtAction(nameof(GetReviews), review);
            }
            return BadRequest("Could not create the review.");
        }
    }
}
