// litt usikker om denne trengs med tanke på Rating.cs har noe som overlapper denne.


public class Review
{
    public int Id { get; set; }

    public int Rating { get; set; }      // 1–5
    public string Comment { get; set; } = "";

    public string UserId { get; set; } = "";

    // Nullable foreign keys (bare én brukes)
    public Movie? Movie { get; set; }

}
