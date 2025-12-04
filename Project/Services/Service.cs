public class ReviewService
{
    public int Id { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; } = string.Empty;
    public int UserId { get; set; }
    public int ProductId { get; set; }
}



