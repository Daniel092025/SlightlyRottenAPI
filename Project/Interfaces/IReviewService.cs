

public interface IReviewService
{
    Task<Review> AddReviewAsync(Review review);
    Task<Review?> UpdateReviewAsync(int reviewId, Review updated);

    Task<List<Review>> GetReviewsByMovieIdAsync(int movieId);
}