using Backend.Models;
using System.Collections.Generic;

namespace Backend.Repository
{
    public interface IReviewRepository
    {
        List<Review> GetAll();
        void Add(Review review);
        bool SaveChanges();
    }
}
