using System.ComponentModel.DataAnnotations;

public class RateMovieDto
{
    
[Range(1,10)]
public int Rating {get; set;}

    
}