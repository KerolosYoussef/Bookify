using System.ComponentModel.DataAnnotations.Schema;

namespace Bookify.Models
{
    public class Genre : BaseModel
    {
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
