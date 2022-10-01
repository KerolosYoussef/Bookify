using Microsoft.AspNetCore.Mvc;

namespace Bookify.Controllers;

public class CartController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}