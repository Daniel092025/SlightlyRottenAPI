using Project.Models;
using Microsoft.EntityFrameworkCore;


public class MovieService : IMovieService
{
    private readonly MovieDatabaseSqlContext _context;

    public MovieService(MovieDatabaseSqlContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
    {
        return await _context.Movies.ToListAsync();
    }

    public async Task<Movie?> GetMovieByImdbIdAsync(string Id)
    {
        return await _context.Movies
            .FirstOrDefaultAsync(m => m.Id == Id);
    }

    public async Task<IEnumerable<Movie>> SearchMoviesAsync(string query)
    {
        return await _context.Movies
            .Where(m => m.Title != null && m.Title.Contains(query))
            .ToListAsync();
    }
}