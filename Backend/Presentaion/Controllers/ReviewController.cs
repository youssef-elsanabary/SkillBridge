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

        public ReviewsController(IReviewRepository repository)
        {
            _repository = repository;
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
    }
}
