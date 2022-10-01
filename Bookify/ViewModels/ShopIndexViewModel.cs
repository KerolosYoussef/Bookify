using Bookify.Models;

namespace Bookify.ViewModels;

public class ShopIndexViewModel
{
    public IEnumerable<Book> Books { get; set; }
    public IEnumerable<Genre> Genres { get; set; }
}