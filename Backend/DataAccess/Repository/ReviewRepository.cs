using Backend.Context;
using Backend.Models;
using Backend.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; 

namespace Backend.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly AppDbContext _context;

        public ReviewRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Review>> GetAllAsync()
        {
            return await _context.Reviews.ToListAsync();
        }

        public async Task AddAsync(Review review)
        {
            await _context.Reviews.AddAsync(review);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await Task.FromResult(_context.SaveChanges() > 0);
        }
        public async Task<double?> GetAverageRatingForFreelancerAsync(int freelancerId)
        {
            var reviews = await _context.Reviews
                                        .Where(r => r.FreelancerId == freelancerId)
                                        .ToListAsync();

            if (reviews.Count == 0) return null;

            return (int?)reviews.Average(r => r.Rating);
        }

        public async Task<IEnumerable<Review>> GetReviewsForFreelancerAsync(int freelancerId)
        {
            return await _context.Reviews
                                 .Where(r => r.FreelancerId == freelancerId)
                                 .ToListAsync();
        }
    }
}
