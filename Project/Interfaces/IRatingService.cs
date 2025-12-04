

public interface IRatingService
{
    Task<double> AddOrUpdateRatingAsync(string imdbId, string userId, int rating);
    Task<double> RemoveRatingAsync(string imdbId, string userId);

    Task<double> GetAverageRatingAsync(string imdbId);
    Task<int> GetUserRatingAsync(string imdbId, string userId);
}
