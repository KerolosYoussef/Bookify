using AutoMapper;
using Bookify.Dtos;
using Bookify.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.Controllers.Api.Admin;

[Authorize(Roles = "Admin")]
public class GenreController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GenreController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [Route("~/Api/Admin/Genre")]
    [HttpGet]
    public IActionResult GetGenre()
    {
        var genres = _unitOfWork.GenreRepository.GetAll();
        var result = _mapper.Map<IEnumerable<GenreDto>>(genres);
        return Ok(result);
    }

    [HttpDelete]
    public IActionResult DeleteGenre(int id)
    {
        var genre = _unitOfWork.GenreRepository.GetById(id);
        if (genre == null)
        {
            return NotFound();
        }
        _unitOfWork.GenreRepository.Delete(genre);
        _unitOfWork.Complete();
        return Ok();
    }
}