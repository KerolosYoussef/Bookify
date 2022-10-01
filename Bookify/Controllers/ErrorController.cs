using Microsoft.AspNetCore.Mvc;

namespace Bookify.Controllers;

public class ErrorController : Controller
{
    [Route("Error/{statusCode}")]
    public IActionResult HttpStatusCodeHandler(int statusCode)
    {
        return statusCode switch
        {
            404 => View("NotFound"),
            _ => RedirectToRoute("Home/Error")
        };
    }
}