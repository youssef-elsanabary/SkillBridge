using Backend.Context;
using Backend.Models;
using Backend.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly AppDbContext _context;

        public ReviewRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Review> GetAll()
        {
            return _context.Reviews.ToList();
        }

        public void Add(Review review)
        {
            _context.Reviews.Add(review);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
