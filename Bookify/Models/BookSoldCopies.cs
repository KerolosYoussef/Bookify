namespace Bookify.Models;

public class BookSoldCopies : BaseModel
{
    public Book Book { get; set; }
    public int BookId { get; set; }
    public int SoldCopies { get; set; }
}