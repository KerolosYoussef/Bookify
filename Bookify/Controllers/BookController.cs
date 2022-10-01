using System.Linq.Expressions;
using AutoMapper;
using Bookify.Data;
using Bookify.Dtos;
using Bookify.Interfaces;
using Bookify.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bookify.Controllers;

public class BookController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public BookController(IUnitOfWork unitOfWork, IMapper mapper, ApplicationDbContext context)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    [Route("Book/{id?}")]
    
    public IActionResult Index(int id)
    {
        var includes = new Expression<Func<Book, object>>[]
        {
            b => b.Author,
            b => b.Genres,
        };
        var book = _unitOfWork.BookRepository.GetById(id, includes,
            source => source.Include(b => b.Reviews).ThenInclude(r => r.User));

        var result = _mapper.Map<BookDto>(book);
        return View(result);
    }
}