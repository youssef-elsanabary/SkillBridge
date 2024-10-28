namespace Backend.BusinessLogic.Interfaces
{
    public interface IAverageRatingService
    {
        Task<int?> CalculateAverageRatingAsync(int freelancerId);
    }

}
