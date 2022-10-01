using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Bookify.Interfaces;
using Bookify.Models;
using Bookify.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.Controllers.Admin;

[Authorize()]
public class AuthorController : BaseAdminController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly INotyfService _notyf;

    public AuthorController(IUnitOfWork unitOfWork, IMapper mapper, INotyfService notyf)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _notyf = notyf;
    }

    [Route("~/Admin/Author")]
    [HttpGet]
    public IActionResult Index()
    {
        return View("~/Views/Admin/Author/Index.cshtml");
    }

    [Route("~/Admin/Author/Add")]
    [HttpGet]
    public IActionResult Add()
    {
        return View("~/Views/Admin/Author/Add.cshtml");
    }

    [Route("~/Admin/Author/Add")]
    [HttpPost]
    public IActionResult Add(AddAuthorViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var author = _mapper.Map<Author>(viewModel);
            _unitOfWork.AuthorRepository.Add(author);
            _unitOfWork.Complete();
            _notyf.Success("Author Added Successfully");
            return RedirectToAction("Index");
        }
        return View("~/Views/Admin/Author/Add.cshtml");
    }

    [Route("~/Admin/Author/Edit/{id}")]
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var author = _unitOfWork.AuthorRepository.GetById(id);
        if (author == null)
        {
            return NotFound();
        }

        var viewModel = _mapper.Map<AddAuthorViewModel>(author);
        return View("~/Views/Admin/Author/Edit.cshtml",viewModel);
    }
    
    [Route("~/Admin/Author/Edit")]
    [HttpPost]
    public IActionResult Edit(AddAuthorViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var author = _unitOfWork.AuthorRepository.GetById(viewModel.Id);
            if (author == null)
            {
                return NotFound();
            }

            author.FirstName = viewModel.FirstName;
            author.LastName = viewModel.LastName;
            _unitOfWork.AuthorRepository.Update(author);
            _unitOfWork.Complete();
            _notyf.Success("Author Updated Successfully");
            return RedirectToAction("Index");
        }
        return View("~/Views/Admin/Author/Edit.cshtml");
    }
}