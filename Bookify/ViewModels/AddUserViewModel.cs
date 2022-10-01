using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bookify.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bookify.ViewModels;

public class AddUserViewModel
{
    public string Id { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    [DisplayName("Display Name")]
    public string DisplayName { get; set; }
    
    [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }
    
    [Required]
    [DisplayName("Role")]
    public string RoleId { get; set; }
}