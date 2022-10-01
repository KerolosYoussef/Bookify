namespace Bookify.Models
{
    public class BookGenre : BaseModel
    {
        public int BooksId { get; set; }
        public int GenresId { get; set; }
        
        public virtual Book Book { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
