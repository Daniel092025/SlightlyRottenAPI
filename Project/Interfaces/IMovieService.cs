using Project.Models;

public interface IMovieService
{
    Task<IEnumerable<Movie>> GetAllMoviesAsync();
    Task<Movie?> GetMovieByImdbIdAsync(string imdbId);
    Task<IEnumerable<Movie>> SearchMoviesAsync(string query);
}
