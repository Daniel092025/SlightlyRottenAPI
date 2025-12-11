// litt usikker om denne trengs med tanke på Rating.cs har noe som overlapper denne.


public class Review
{
    public string? Id { get; set; }

    public int Rating { get; set; }      // 1–5
    public string Comment { get; set; } = "";

    public string UserId { get; set; } = "";

    // Nullable foreign keys (bare én brukes)
    public string? Movie { get; set; }
     public int? MovieId { get; set; }

}
