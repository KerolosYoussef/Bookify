using Bookify.Models;

namespace Bookify.Dtos;

public class BookDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public int NumberOfCopies { get; set; }
    public DateTime PublicationDate { get; set; }
    public string ImagePath { get; set; }
    
    public string Author { get; set; }
    public ICollection<ReviewDto> Reviews { get; set; }
    public int BookSoldCopies { get; set; }
    public virtual ICollection<GenreDto> Genres { get; set; }
}