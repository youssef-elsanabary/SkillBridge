using Backend.BusinessLogic.Interfaces;
using Backend.Models;
using Backend.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewRepository _repository;
        private readonly IAverageRatingService _averageRatingService;

        public ReviewsController(IReviewRepository repository, IAverageRatingService averageRatingService)
        {
            _repository = repository;
            _averageRatingService = averageRatingService;
        }

        [HttpGet]
        public async Task<IActionResult> GetReviews()
        {
            var reviews = await _repository.GetAllAsync();
            return Ok(reviews);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReview([FromBody] Review review)
        {
            await _repository.AddAsync(review);
            if (await _repository.SaveChangesAsync())
            {
                return CreatedAtAction(nameof(GetReviews), review);
            }
            return BadRequest("Could not create the review.");
        }
        [HttpGet("{freelancerId}/reviews")]
        public async Task<IActionResult> GetReviewsForFreelancer(int freelancerId)
        {
            var reviews = await _repository.GetReviewsForFreelancerAsync(freelancerId);
            return Ok(reviews);
        }

        [HttpGet("{freelancerId}/average-rating")]
        public async Task<IActionResult> GetAverageRatingForFreelancer(int freelancerId)
        {
            var averageRating = await _repository.GetAverageRatingForFreelancerAsync(freelancerId);

            if (averageRating == null)
                return NotFound("No reviews found for this freelancer.");

            return Ok(new { AverageRating = averageRating });
        }



    }
}
