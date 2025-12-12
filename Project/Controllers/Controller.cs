
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Project.controllers;


[ApiController]
[Route("api/movies")]
    public class Controller : ControllerBase
    {
    //Get all movies = /Movies
    //Get  Movie by ID = /Movie/{ID} //
    //Get  Movie search string = /Movie/{Tittle}
    //Get  Movie by top 10 = Movie/Top10
    //Post Movie rating = Movie/Rate
    //Post Movie review = Movie/Review //
    //post new Movie = Movies/New //
    //Delete Movie = Movie/Delete/{ID} //
    //Update Movie = Movie/Update/{ID} //

    
    //Nice to have !
    // Get movie by year = Movie/{Year}
    // 
    private  readonly MovieDatabaseSqlContext _context;
     private  readonly IReviewService _reviewservice;
    
     public Controller(MovieDatabaseSqlContext context, IReviewService reviewService)
    {
       
       _context = context;
       _reviewservice = reviewService;
   
    }  
        [HttpGet()] //" Get all movies"
        public async Task<ActionResult<IEnumerable<Movie>>>GetMovies(
             
             [FromQuery] string? search = null,
             [FromQuery] int page = 1,
             [FromQuery] int pagesize = 20)
    {
        if(page < 1) page = 1;
        if(pagesize < 20) pagesize = 20;
        if(pagesize > 100) pagesize = 100;
        
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
    [HttpGet("Top10")]
    public async Task<ActionResult<IEnumerable<Movie>>> GetTop10movies()
    {
        var Top10 = await _context.Movies
        .OrderByDescending(m => m.Rating)
        .Take(10)
        .AsNoTracking()
        .ToListAsync();
        return Ok(Top10);

    }


    [HttpGet("{id}/")]//Get Movie
        public async Task<ActionResult<Movie>> GetMovie(string id)
     {
        var movie = await _context.Movies
        .AsNoTracking()
        .FirstOrDefaultAsync(m => m.Id == id);

       return movie is null? NotFound() : Ok(movie);
    }
    
    [HttpPost("/New")]
    public async Task<ActionResult<Movie>> Create([FromBody] Movie movie)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMovie),
            new {id = movie.Id}, movie);

        
     }   
        [HttpPut("/Update")]
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
    
    [HttpDelete("{id}/Delete")]
    public async Task<ActionResult>Delete(string id )
    {
      var movie = await _context.Movies.FindAsync(id);
      if (movie == null)
      return NotFound();

      _context.Movies.Remove(movie);
      await _context.SaveChangesAsync();
      return NoContent();
    }
    
    [HttpPatch("/updatereview")]
    public async Task<IActionResult> UpdateReview(string id, [FromBody] ReviewDto dto)

    {
        var existing = await _context.Movies.FindAsync(id);
        if (existing == null)
        return NotFound();

        existing.Review = dto.Review; 

        await _context.SaveChangesAsync();
        return  NoContent();        
    }
    [HttpPatch("/rating")]
    public async Task<IActionResult> RateMovie(string id,[FromBody]RateMovieDto dto)
    {
        if(!ModelState.IsValid)
        return BadRequest(ModelState);

        var movie = await _context.Movies.FindAsync(id);
        if (movie == null)
        return NotFound("Fant ikke filmen");

        movie.Rating =dto.Rating;

        await _context.SaveChangesAsync();
        return NoContent();

    }
   
    
    }

    




