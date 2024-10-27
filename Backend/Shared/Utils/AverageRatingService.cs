using Backend.BusinessLogic.Interfaces;
using Backend.Repository;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Shared.Utils
{


    public class AverageRatingService : IAverageRatingService
    {
        private readonly IReviewRepository _reviewRepository;

        public AverageRatingService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<int?> CalculateAverageRatingAsync(int freelancerId)
        {
            var reviews = await _reviewRepository.GetReviewsForFreelancerAsync(freelancerId);

            if (!reviews.Any()) return null;

            return (int?)reviews.Average(r => r.Rating);
        }
    }

}
