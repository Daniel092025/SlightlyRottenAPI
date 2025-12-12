using System.ComponentModel.DataAnnotations;

public class RateMovieDto
{

public string? Id { get; set; }

[Range(1,10)]
public int Rating { get; set; } 
    
}