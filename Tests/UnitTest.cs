using Xunit;



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
    public void Movie_PropertiesCanBeNull()
    {
        // Arrange & Act
        var movie = new Movie
        {
            Id = null,
            Title = null,
            Genre = null,
            Director = null,
            Actors = null
        };
        // Assert
        Assert.Null(movie.Id);
        Assert.Null(movie.Title);
        Assert.Null(movie.Genre);
        Assert.Null(movie.Director);
        Assert.Null(movie.Actors);
        
        // Then
    }
    
    [Theory]
    [InlineData(1920)]
    [InlineData(2008)]
    [InlineData(2024)]
    public void Movie_CanHaveDifferentYears(int year)
    {
        // Arrange & Act
        var movie = new Movie { Year = year };

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
        var movie = new Movie { Playtime = playtime };

        // Assert
        Assert.Equal(playtime, movie.Playtime);
    }       
}