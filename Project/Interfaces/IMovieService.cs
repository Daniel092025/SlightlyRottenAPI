using Project.Models;

public interface IMovieService
{
    Task<IEnumerable<Movie>> GetAllMoviesAsync();
    Task<Movie?> GetMovieByImdbIdAsync(string Id);
    Task<IEnumerable<Movie>> SearchMoviesAsync(string query);
}
