// litt usikker om denne trengs med tanke på Rating.cs har noe som overlapper denne.


public class Review
{
    public string? Id { get; set; }
    public double Rating { get; set; }     
    public string Comment { get; set; } = "";
    public string? MovieId { get; set; }

}

