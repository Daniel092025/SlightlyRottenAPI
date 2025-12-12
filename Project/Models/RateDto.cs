using System.ComponentModel.DataAnnotations;

public class RateMovieDto
{
    
[Range(1,10)]

public string? Id { get; set; }
public double Rating { get; set; } 
    
}