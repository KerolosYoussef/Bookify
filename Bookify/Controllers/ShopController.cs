using Bookify.Interfaces;
using Bookify.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.Controllers
{
    public class ShopController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ShopController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var genres = _unitOfWork.GenreRepository.GetAll();
            var viewModel = new ShopIndexViewModel
            {
                Genres = genres
            };
            return View(viewModel);
        }
        
    }
}
