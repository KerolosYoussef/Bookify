using System.ComponentModel.DataAnnotations;
using Bookify.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace Bookify.Models;

public class Review : BaseModel
{
    [Required]
    public int BookId { get; set; }
    [Required]
    public User User { get; set; }
    public string UserId { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; }
    public DateTime Date { get; set; }


}