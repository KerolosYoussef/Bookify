using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Bookify.Interfaces;
using Bookify.Models;
using Bookify.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.Controllers.Admin;

public class GenreController : BaseAdminController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly INotyfService _notyf;
    private readonly IMapper _mapper;

    public GenreController(IUnitOfWork unitOfWork, INotyfService notyf, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _notyf = notyf;
        _mapper = mapper;
    }

    [Route("/Admin/Genre")]
    public IActionResult Index()
    {
        return View("~/Views/Admin/Genre/Index.cshtml");
    }

    [Route("/Admin/Genre/Add")]
    public IActionResult Add()
    {
        return View("~/Views/Admin/Genre/Add.cshtml");
    }
    
    [Route("/Admin/Genre/Add")]
    [HttpPost]
    public IActionResult Add(AddGenreViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var genre = _mapper.Map<Genre>(viewModel);
            _unitOfWork.GenreRepository.Add(genre);
            _unitOfWork.Complete();
            _notyf.Success("Genre Added Successfully");
            return RedirectToAction("Index");
        }
        _notyf.Error("Something went wrong");
        return View("~/Views/Admin/Genre/Add.cshtml");
    }
    
    [Route("/Admin/Genre/Edit/{id}")]
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var genre = _unitOfWork.GenreRepository.GetById(id);
        if (genre == null)
        {
            _notyf.Error("This genre is not available");
            return RedirectToAction("Index");
        }
        var viewModel = _mapper.Map<AddGenreViewModel>(genre);
        return View("~/Views/Admin/Genre/Edit.cshtml",viewModel);
    }

    [HttpPost]
    [Route("~/Admin/Genre/Edit")]
    public IActionResult Edit(AddGenreViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var genre = _mapper.Map<Genre>(viewModel);
            _unitOfWork.GenreRepository.Update(genre);
            _unitOfWork.Complete();
            _notyf.Success("Genre Updated Successfully");
            return RedirectToAction("Index");
        }
        _notyf.Error("Something went wrong");
        return RedirectToAction("Edit",viewModel.Id);
    }
}