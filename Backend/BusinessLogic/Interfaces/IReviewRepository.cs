using Backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Repository
{
    public interface IReviewRepository
    {
        Task<List<Review>> GetAllAsync();
        Task AddAsync(Review review);
        Task<bool> SaveChangesAsync();
        Task<double?> GetAverageRatingForFreelancerAsync(int freelancerId);  
        Task<IEnumerable<Review>> GetReviewsForFreelancerAsync(int freelancerId);
    }
}
