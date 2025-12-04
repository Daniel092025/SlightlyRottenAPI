

public interface IStatisticService
{
    Task<double> GetAverageRatingAsync(string imdbId);
    Task<int> GetReviewCountAsync(string imdbId);
    Task<Dictionary<int, int>> GetRatingDistributionAsync(string imdbId);

    Task<IEnumerable<TopRatedItem>> GetTopRatedMoviesAsync(int count = 10);
    // litt usikker om den under trengs siden det finnes filmserier og TV-serier
    Task<IEnumerable<TopRatedItem>> GetTopRatedSeriesAsync(int count = 10); 
}
public class TopRatedItem
{
    public string ImdbId { get; set; }
    public string Title { get; set; }
    public double AverageRating { get; set; }
    public int ReviewCount { get; set; }
}