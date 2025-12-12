using Project.Models;
using Microsoft.EntityFrameworkCore;

public class ReviewService : IReviewService
{
    private readonly MovieDatabaseSqlContext _context;
    public ReviewService(MovieDatabaseSqlContext context)
    {
        _context = context;
    }

    public async Task<ReviewDto> AddReviewAsync(ReviewDto review)
    {
        _context.Reviews.Add(review);
        await _context.SaveChangesAsync();
        return review;
    }
}
/*     public async Task<ReviewDto?> UpdateReviewAsync (int reviewId, ReviewDto updated)
    {
        var existingReview = await _context.Reviews.FindAsync(reviewId);

        if (existingReview == null)
            return null;

        existingReview.Rating = updated.Rating;
        existingReview.Comment = updated.Comment;

        await _context.SaveChangesAsync();
        return existingReview;

        
    }
    public async Task<List<ReviewDto>> GetReviewsByMovieIdAsync(string MovieId)
    {
        return await _context.Reviews
        .Where(r => r.MovieId == MovieId)
        .OrderByDescending(r => r.Id)
        .ToListAsync();
    }
} */



