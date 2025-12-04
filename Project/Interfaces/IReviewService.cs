

public interface IReviewService
{
    Task<ReviewService> AddReviewAsync(ReviewService review);
    Task<ReviewService?> UpdateReviewAsync(int reviewId, ReviewService updated);
}