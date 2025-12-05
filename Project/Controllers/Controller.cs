using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Project.Database;
using System.Threading.Tasks;


    public class MoviesController : Controller
    {
    
    
    private  readonly MovieDb _context;
     private  readonly IReviewService _reviewservice;
    
     public MoviesController (MovieDb context, IReviewService reviewService)
    {
       
       _context = context;
       _reviewservice = reviewService;
   
    }  

        public async Task<IActionResult> Index()
    {
        var movie = await _context.Movies
        .OrderBy(m => m.Title)
        .ToListAsync();
       
        return View(movie);

    }


}


