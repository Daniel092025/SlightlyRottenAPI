using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Project.Models;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

[ApiController]
[Route("api/Controller")]
    public class MoviesController : ControllerBase
    {
    
    
    private  readonly MovieDatabaseSqlContext _context;
     private  readonly IReviewService _reviewservice;
    
     public MoviesController(MovieDatabaseSqlContext context, IReviewService reviewService)
    {
       
       _context = context;
       _reviewservice = reviewService;
   
    }  
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>>GetMovies(
             
             [FromQuery] string? search = null,
             [FromQuery] int page = 1,
             [FromQuery] int pagesize = 20)
    {
        if(page < 1) page = 1;
        if(pagesize < 20) pagesize = 20;
        if(pagesize < 100) pagesize = 100;
        
        var query = _context.Movies.AsQueryable();

        if(!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(m => m.Title.Contains(search, StringComparison.CurrentCultureIgnoreCase));
        }

        query = query
        .OrderBy(m => m.Title)
        .OrderBy(m => m.Playtime);
             
    
        var movies = await _context.Movies
        .Skip(( page -1)* pagesize)
        .Take(pagesize)
        .ToListAsync();
       
        return Ok(movies);

    }
    [HttpGet("{id:string}")]
        public async Task<ActionResult<Movie>> GetMovie(string id)
     {
        var movie = await _context.Movies
        .AsNoTracking()
        .FirstOrDefaultAsync(m => m.Id == id);

       return movie is null? NotFound() : Ok(movie);
    }
    
    [HttpPost]
    public async Task<ActionResult<Movie>>Create([FromBody] Movie movie)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(" id route and body must match");
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMovie),
            new {id = movie.Id}, movie);

        }
     }   
        [HttpPut("{id:string}")]
        public async Task<IActionResult>Update(string id, [FromBody] Movie movie)
     {
        if(id != movie.Id)     

        return BadRequest();

        if(!ModelState.IsValid)

        return BadRequest(ModelState);

        _context.Entry(movie).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();   

        }
        catch (DbUpdateConcurrencyException)
        {
            if(!await _context.Movies.AnyAsync(m => m.Id == id))
            return NotFound();
            throw;
        }
            return NoContent();
    }
    
    [HttpDelete("{id:string}")]
    public async Task<ActionResult>Delete(string id )
    {
      var movie = await _context.Movies.FindAsync(id);
      if (movie == null)
      return NotFound();

      _context.Movies.Remove(movie);
      await _context.SaveChangesAsync();
      return NoContent();
    }
    
    [HttpGet("{id:int}/review")]
    public async Task<ActionResult<IEnumerable<Review>>>GetReviews(string id)

    {
        var exist = await _context.Movies.AnyAsync(m => m.Id ==id);
        if(!exist)
        return NotFound();

        var rewiews = await _reviewservice.GetReviews(id);
        return Ok(rewiews);
        
    }
    

    }




