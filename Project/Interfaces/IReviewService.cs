

public interface IReviewService
{
    Task<Review> AddReviewAsync(Review review);
    Task<Review?> UpdateReviewAsync(int reviewId, Review updated);
}