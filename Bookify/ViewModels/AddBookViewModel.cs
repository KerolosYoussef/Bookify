using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Bookify.Dtos;
using Bookify.Models;

namespace Bookify.ViewModels;

public class AddBookViewModel
{
    public AddBookViewModel()
    {
        Authors = new List<Author>();
        Genres = new List<Genre>();
        PublicationDate = DateTime.Now;
    }

    public AddBookViewModel(List<Author> authors, List<Genre> genres)
    {
        Authors = authors;
        Genres = genres;
        PublicationDate = DateTime.Now;
    }
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    [MinLength(15)]
    public string Description { get; set; }
    [Required]
    public double Price { get; set; }
    [Required]
    [DisplayName("Number of Copies")]
    public int NumberOfCopies { get; set; }
    [Required]
    [DisplayName("Publication Date")]
    public DateTime PublicationDate { get; set; }
    [DisplayName("Image")]
    public IFormFile Image { get; set; }
    [Required]
    [DisplayName("Author")]
    public int? AuthorId { get; set; }
    [Required]
    [DisplayName("Genres")]
    public IList<int> GenreIds { get; set; }
    public IEnumerable<Author> Authors { get; set; }
    public IEnumerable<Genre> Genres { get; set; }
}