using Project.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

public class ReviewService : IReviewService
{
    private readonly MovieDatabaseSqlContext _context;
    public ReviewService(MovieDatabaseSqlContext context)
    {
        _context = context;
    }

    public async Task<Review> AddReviewAsync(Review review)
    {
        _context.Reviews.Add(review);
        await _context.SaveChangesAsync();
        return review;
    }
    public async Task<Review?> UpdateReviewAsync (int reviewId, Review updated)
    {
        var existingReview = await _context.Reviews.FindAsync(reviewId);

        if (existingReview == null)
            return null;

        existingReview.Rating = updated.Rating;
        existingReview.Comment = updated.Comment;
        existingReview.UserId = updated.UserId;

        await _context.SaveChangesAsync();
        return existingReview;

        
    }
    public async Task<List<Review>> GetReviewsByMovieIdAsync(string MovieId)
    {
        return await _context.Reviews
        .Where(r => r.MovieId == MovieId)
        .OrderByDescending(r => r.Id)
        .ToListAsync();
    }
}



