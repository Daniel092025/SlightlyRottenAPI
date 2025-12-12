using System.ComponentModel.DataAnnotations;

public class RateMovieDto
{
[Required]
[Range(1,10)]
public int Rating {get; set;}

public string? comment {get;set;}

[Required]
public string? Username{get; set;} = "";

    
}