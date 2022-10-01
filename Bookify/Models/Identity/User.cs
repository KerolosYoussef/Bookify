using System.ComponentModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;

namespace Bookify.Models.Identity;

public class User : IdentityUser
{
    [DisplayName("Display Name")]
    public string DisplayName { get; set; }
    public string ProfileImagePath { get; set; }
    public Address Address { get; set; }
}