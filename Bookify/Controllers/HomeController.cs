using Bookify.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq.Expressions;
using AutoMapper;
using Bookify.Dtos;
using Bookify.Helpers;
using Bookify.Interfaces;

namespace Bookify.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var includes = new Expression<Func<Book, object>>[]
            {
                p => p.Author,
                p => p.Genres,
                p => p.BookSoldCopies
            };
            
            var books = _unitOfWork.BookRepository.GetAll(
                includes, 
                b => b.BookSoldCopies.SoldCopies,
                OrderByTypes.OrderByDescending,
                8
            );

            var result = _mapper.Map<IEnumerable<BookDto>>(books);
            
            return View(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}