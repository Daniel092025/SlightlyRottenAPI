using Xunit;
using Project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;


public class MovieTests
{
    [Fact]
    public void Movie_CanBeCreated_WithValidValues()
    {
        // Arrange & Act
        var movie = new Movie
        {
            Id = "tt0468569",
            Title = "The Dark Knight",
            Genre = "Drama | Action",
            Director = "Christopher Nolan",
            Actors = "Johnny Krist",
            Year = 2008,
            Playtime = 152,
        };
        // Assert
        Assert.NotNull(movie);
        Assert.Equal("tt0468569", movie.Id);
        Assert.Equal("The Dark Knight", movie.Title);
        Assert.Equal("Drama | Action", movie.Genre);
        Assert.Equal("Christopher Nolan", movie.Director);
        Assert.Equal("Johnny Krist", movie.Actors);
        Assert.Equal(2008, movie.Year);
        Assert.Equal(152, movie.Playtime);

    
    }

    [Fact]
    public void Movie_OptionalPropertiesCanBeNull()
    {
        // Arrange & Act
        var movie = new Movie
        {
            Id = "tt0000000", // Id is required, kan ikke være null
            Title = null,
            Genre = null,
            Director = null,
            Actors = null
        };
        // Assert
        Assert.NotNull(movie.Id); // Id skal alltid ha verdi
        Assert.Null(movie.Title);
        Assert.Null(movie.Genre);
        Assert.Null(movie.Director);
        Assert.Null(movie.Actors);
        
        
    }
    
    [Theory]
    [InlineData(1920)]
    [InlineData(2008)]
    [InlineData(2024)]
    public void Movie_CanHaveDifferentYears(int year)
    {
        // Arrange & Act
        var movie = new Movie { Id = "tt0000000", Year = year };

        // Assert
        Assert.Equal(year, movie.Year);
    }


    [Theory]
    [InlineData(90)]
    [InlineData(152)]
    [InlineData(180)]
    public void Movie_CanHaveDifferentPlaytimes(int playtime)
    {
        // Arrange & Act
        var movie = new Movie { Id = "tt0000000", Playtime = playtime };

        // Assert
        Assert.Equal(playtime, movie.Playtime);
    }   

    public class MoviesControllerTests
{
    [Fact]
    public async Task GetMovie_ReturnsOk_WhenMovieExists()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<MovieDatabaseSqlContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        
        var context = new MovieDatabaseSqlContext(options);
        var reviewService = new ReviewService(context);
        var controller = new Controller(context, reviewService);
        
        context.Movies.Add(new Movie { Id = "tt123", Title = "Test Movie" });
        await context.SaveChangesAsync();

        // Act
        var result = await controller.GetMovie("tt123");

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var movie = Assert.IsType<Movie>(okResult.Value);
        Assert.Equal("Test Movie", movie.Title);
    }
}    
}