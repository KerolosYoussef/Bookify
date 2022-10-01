using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Bookify.Dtos;
using Bookify.Models;

namespace Bookify.ViewModels;

public class AddGenreViewModel
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
}