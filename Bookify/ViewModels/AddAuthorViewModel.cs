using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bookify.ViewModels;

public class AddAuthorViewModel
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
}