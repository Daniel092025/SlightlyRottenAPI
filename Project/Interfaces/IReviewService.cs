

public interface IReviewService
{
    Task<Review> AddReviewAsync(Review review);
    Task<Review?> UpdateReviewAsync(int reviewId, Review updated);

    Task<List<Review>> GetReviewsByMovieIdAsync(int movieId);
}

public interface IRatingService
{
    Task<double> AddOrUpdateRatingAsync(string Id, string userId, int rating);
    Task<double> RemoveRatingAsync(string Id, string userId);

    Task<double> GetAverageRatingAsync(string Id);
    Task<int> GetUserRatingAsync(string Id, string userId);
}
