using Bookify.Interfaces;
using Bookify.Models.Identity;
using Bookify.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.Controllers.Admin;

public class AdminController : BaseAdminController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly UserManager<User> _userManager;

    public AdminController(IUnitOfWork unitOfWork, UserManager<User> userManager)
    {
        _unitOfWork = unitOfWork;
        _userManager = userManager;
    }

    [Route("~/Admin")]
    [Route("~/Admin/Dashboard")]
    public IActionResult Dashboard()
    {
        var booksNumber = _unitOfWork.BookRepository.Count();
        var genresNumber = _unitOfWork.GenreRepository.Count();
        var usersNumber = _userManager.Users.Count();
        var ordersNumber = _unitOfWork.OrderRepository.Count();
        var viewModel = new AdminDashboardViewModel
        {
            BooksNumber = booksNumber,
            GenresNumber = genresNumber,
            UsersNumber = usersNumber,
            OrdersNumber = ordersNumber,
        };
        return View(viewModel);
    }
}