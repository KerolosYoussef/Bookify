namespace Bookify.Dtos;

public class ReviewDto
{
    public string User { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; }
    public DateTime Date { get; set; }
}