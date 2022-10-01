using System.Linq.Expressions;
using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Bookify.Dtos;
using Bookify.Helpers;
using Bookify.Interfaces;
using Bookify.Models;
using Bookify.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.Controllers.Admin;

public class BookController : BaseAdminController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IWebHostEnvironment _hostEnvironment;
    private readonly INotyfService _notyf;


    public BookController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment, INotyfService notyf, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _hostEnvironment = hostEnvironment;
        _notyf = notyf;
        _mapper = mapper;
    }

    [Route("~/Admin/Book")]
    public IActionResult Index()
    {
        return View("~/Views/Admin/Book/Index.cshtml");
    }
    
    [Route("~/Admin/Book/Add")]
    public IActionResult Add()
    {
        var genres = (List<Genre>)_unitOfWork.GenreRepository.GetAll();
        var authors =(List<Author>)_unitOfWork.AuthorRepository.GetAll();
        var viewModel = new AddBookViewModel(authors, genres);
        return View("~/Views/Admin/Book/Add.cshtml",viewModel);
    }

    [HttpPost]
    [Route("~/Admin/Book/Add")]
    public IActionResult Add(AddBookViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            // upload book image
            string uniqueFileName = null;
            if (viewModel.Image != null)
            {
                uniqueFileName = ImageUploadHandler.UploadImage(viewModel.Image, _hostEnvironment);
            }
            ICollection<Genre> genres =
                (ICollection<Genre>) _unitOfWork.GenreRepository.FindAll(g => viewModel.GenreIds.Contains(g.Id));

            var newBook = new Book()
            {
                Title = viewModel.Title,
                Price = viewModel.Price,
                AuthorId = viewModel.AuthorId,
                Description = viewModel.Description,
                ImagePath = uniqueFileName,
                PublicationDate = viewModel.PublicationDate,
                BookSoldCopies = new BookSoldCopies()
                {
                    SoldCopies = 0
                },
                NumberOfCopies = viewModel.NumberOfCopies,
                Genres = genres
            };
            _unitOfWork.BookRepository.Add(newBook);
            _unitOfWork.Complete();
            _notyf.Success("Book Created Successfully");
            return RedirectToAction("Index");
        }

        var authors = (List<Author>) _unitOfWork.AuthorRepository.GetAll();
        var genresList = (List<Genre>) _unitOfWork.GenreRepository.GetAll();
        viewModel = new AddBookViewModel(authors, genresList);
        return View("~/Views/Admin/Book/Add.cshtml",viewModel);
    }

    [Route("~/Admin/Book/Edit/{id}")]
    public IActionResult Edit(int id)
    {
        var includes = new Expression<Func<Book, object>>[]
        {
            b => b.Genres
        };
        var book = _unitOfWork.BookRepository.GetById(id,includes);
        if (book == null)
        {
            _notyf.Error("Wrong book id");
            return RedirectToAction("Index");
        }
        var authors = (List<Author>)_unitOfWork.AuthorRepository.GetAll();
        var genres = (List<Genre>) _unitOfWork.GenreRepository.GetAll();
        var viewModel = new AddBookViewModel(authors, genres)
        {
            Id = id,
            Title = book.Title,
            Description = book.Description,
            AuthorId = book.AuthorId,
            Price = book.Price,
            PublicationDate = book.PublicationDate,
            GenreIds = book.Genres.Select(g => g.Id).ToList(),
            NumberOfCopies = book.NumberOfCopies,
        };
        return View("~/Views/Admin/Book/Edit.cshtml",viewModel);
    }
    
    [HttpPost]
    [Route("~/Admin/Book/Edit")]
    public IActionResult Edit(AddBookViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var includes = new Expression<Func<Book, object>>[]
            {
                b => b.Genres
            };
            var book = _unitOfWork.BookRepository.GetById(viewModel.Id,includes);
            if (book == null)
            {
                _notyf.Error("Wrong Book Id");
                RedirectToAction("Index");
            }
            string uniqueFileName = null;
            if (viewModel.Image != null)
            {
                var uploadFolder = Path.Combine(_hostEnvironment.WebRootPath, "img");
                uniqueFileName = Guid.NewGuid() + "_" + Path.GetFileName(viewModel.Image.FileName);;
                var filePath = Path.Combine(uploadFolder,uniqueFileName);
                var fileStream = new FileStream(filePath, FileMode.Create);
                viewModel.Image.CopyTo(fileStream);
                fileStream.Close();
            }
            ICollection<Genre> genres =
                (ICollection<Genre>) _unitOfWork.GenreRepository.FindAll(g => viewModel.GenreIds.Contains(g.Id));
            
            book.Title = viewModel.Title;
            book.Price = viewModel.Price;
            book.AuthorId = viewModel.AuthorId;
            book.Description = viewModel.Description;
            book.PublicationDate = viewModel.PublicationDate;
            book.NumberOfCopies = viewModel.NumberOfCopies;
            if (uniqueFileName != null)
            {
                book.ImagePath = uniqueFileName;
            }

            book.Genres.Clear();
            book.Genres = genres;
            _unitOfWork.BookRepository.Update(book);
            _unitOfWork.Complete();
            _notyf.Success("Book Updated Successfully");
            return RedirectToAction("Index");
        }

        var authors = (List<Author>) _unitOfWork.AuthorRepository.GetAll();
        var genresList = (List<Genre>) _unitOfWork.GenreRepository.GetAll();
        viewModel = new AddBookViewModel(authors, genresList);
        return RedirectToAction("Index",viewModel.Id);
    }
}