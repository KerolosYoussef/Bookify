using System.Linq.Expressions;
using AutoMapper;
using Bookify.Data;
using Bookify.Dtos;
using Bookify.Helpers;
using Bookify.Interfaces;
using Bookify.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace Bookify.Controllers.Api;


public class BookController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public BookController(IUnitOfWork unitOfWork, IMapper mapper, ApplicationDbContext context)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<Pagination<BookDto>> GetBooks([FromQuery] ShopFilters shopFilters,bool dataTable = false)
    {
        
        // Models to include with books
        var includes = new Expression<Func<Book, object>>[]
        {
            b => b.Genres,
            b => b.Author,
            b => b.BookSoldCopies,
        };
        
        // Books Query Criteria
        Expression<Func<Book, bool>> criteria = b =>
            ((string.IsNullOrEmpty(shopFilters.Search)) || b.Title.ToLower().Contains(shopFilters.Search))
            && (!shopFilters.Genre.HasValue || b.Genres.Any(g => g.Id == shopFilters.Genre))
            && (b.Price >= shopFilters.Min && b.Price <= shopFilters.Max);

        
        // Total Number of Books 
        var totalItems = _unitOfWork.BookRepository.Count(criteria);
        
        // return books with filters (search and pagination if found) and eager loading array of includes
        var books = _unitOfWork.BookRepository.FindAll(
            criteria,
            includes,
            shopFilters
        );
        
        // Map Book model to BookDto Model
        var result = _mapper.Map<IEnumerable<BookDto>>(books);
        
        // Return result with pagination
        return dataTable
            ? Ok(result)
            : Ok(new Pagination<BookDto>(shopFilters.PageNumber, shopFilters.PageSize, totalItems, result));
    }
    
    [HttpGet]
    [Route("~/Api/Admin/Book")]
    [Authorize(Roles = "Admin")]
    public ActionResult<IEnumerable<BookDto>> GetBooksDataTable()
    {
        
        // Models to include with books
        var includes = new Expression<Func<Book, object>>[]
        {
            b => b.Genres,
            b => b.Author,
            b => b.BookSoldCopies,
        };
        
        var books = _unitOfWork.BookRepository.GetAll(includes);
        
        // Map Book model to BookDto Model
        var result = _mapper.Map<IEnumerable<BookDto>>(books);
        
        // Return result with pagination
        return Ok(result);
    }
    
    [HttpDelete]
    [Authorize(Roles = "Admin")]
    public IActionResult DeleteBook(int id)
    {
        var book = _unitOfWork.BookRepository.GetById(id);
        if (book == null)
        {
            return NotFound();
        }
        
        _unitOfWork.BookRepository.Delete(book);
        _unitOfWork.Complete();
        return Ok();

    }
}