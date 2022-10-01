using Bookify.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.Controllers;

[Authorize]
public class CheckoutController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}