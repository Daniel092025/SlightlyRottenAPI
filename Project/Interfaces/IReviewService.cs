

public interface IReviewService
{
    Task<Review> AddReviewAsync(Review review);
    Task<Review?> UpdateReviewAsync(int reviewId, Review updated);

    Task<List<Review>> GetReviewsByMovieIdAsync(string movieId);
    Task AddReviewAsync(string id, string? username, int rating, string? comment);
}

public interface IRatingService
{
    Task<double> AddOrUpdateRatingAsync(string Id, int rating);
    Task<double> RemoveRatingAsync(string Id);

    Task<double> GetAverageRatingAsync(string Id);
    Task<int> GetUserRatingAsync(string Id);
}
