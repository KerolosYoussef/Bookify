using Bookify.Dtos;

namespace Bookify.Models
{
    public class Book : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int NumberOfCopies { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public DateTime PublicationDate { get; set; }
        public string ImagePath { get; set; }
        public Author Author { get; set; }
        public int? AuthorId { get; set; }

        public BookSoldCopies BookSoldCopies { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
