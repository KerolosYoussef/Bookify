using Bookify.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.Controllers.Api.Admin;

[Authorize(Roles = "Admin")]
public class AuthorController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;

    public AuthorController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [Route("~/Api/Admin/Author")]
    [HttpGet]
    public IActionResult GetAuthors()
    {
        var authors = _unitOfWork.AuthorRepository.GetAll();
        return Ok(authors);
    }

    [HttpDelete]
    public IActionResult DeleteAuthor(int id)
    {
        var author = _unitOfWork.AuthorRepository.GetById(id);
        if (author == null)
        {
            return NotFound();
        }
        // Delete The books of the author
        var booksOfAuthor = _unitOfWork.BookRepository.FindAll(b => b.AuthorId == id);
        _unitOfWork.BookRepository.DeleteRange(booksOfAuthor);
        _unitOfWork.AuthorRepository.Delete(author);
        _unitOfWork.Complete();
        return Ok();
    }
}