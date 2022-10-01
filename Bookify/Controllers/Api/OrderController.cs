using System.Linq.Expressions;
using AutoMapper;
using Bookify.Dtos;
using Bookify.Helpers;
using Bookify.Interfaces;
using Bookify.Models;
using Bookify.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.Controllers.Api;

[Authorize]
public class OrderController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IBasketRepository _basketRepository;
    private readonly OrderTransaction _orderTransaction;
    private readonly UserManager<User> _userManager;

    public OrderController(IUnitOfWork unitOfWork, IMapper mapper,
        IBasketRepository basketRepository, UserManager<User> userManager)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _basketRepository = basketRepository;
        _userManager = userManager;
        _orderTransaction = new OrderTransaction(_unitOfWork);
    }

    [Route("~/Api/Order/Create")]
    [HttpPost]
    public IActionResult CreateOrder([FromForm] OrderDto orderDto)
    {
        if (!ModelState.IsValid)
        {
            var errors = string.Join(" | ", ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
            var errorResponse = new {errors};
            return BadRequest(errorResponse);
        }

        var order = _mapper.Map<Order>(orderDto);
        var basketBookItems = _basketRepository.GetBasket(orderDto.BasketId).BasketItems;
        var basketBookTitles = basketBookItems.Select(i => i.BookTitle);
        var books = _unitOfWork
            .BookRepository
            .FindAll(b => basketBookTitles.Contains(b.Title));
        order.Books = books.ToList();
        order.Status = "Pending";
        _unitOfWork.OrderRepository.Add(order);
        _unitOfWork.Complete();
        _orderTransaction.AddQuantityToBookOrder(order,basketBookItems);
        return Ok(order);
    }

    [Route("~/Api/Orders")]
    [HttpGet]
    public IActionResult GetOrders([FromQuery] PaginationFilters paginationFilters)
    {
        // get user id
        var userId = _userManager.FindByNameAsync(User.Identity?.Name).Result.Id;

        // Get only logged in user's orders
        Expression<Func<Order, bool>> criteria = o => o.CustomerId == userId;
        
        // Get Total number of orders for logged in user
        var ordersCount = _unitOfWork.OrderRepository.Count(criteria);
        
        var orders = _unitOfWork.OrderRepository
            .FindAll(criteria, null, paginationFilters, null, o => o.Date, OrderByTypes.OrderByDescending);

        // Map Orders objects into OrderDto objects
        var result = _mapper.Map<IEnumerable<OrderDto>>(orders);
        
        // return Response with pagination
        return Ok(new Pagination<OrderDto>(paginationFilters.PageNumber, paginationFilters.PageSize, ordersCount,
            result));
    }

    [Route("~/Api/Order/")]
    [HttpPost]
    public IActionResult GetOrderById([FromForm] int id)
    {
        var includes = new Expression<Func<Order, object>>[]
        {
            o => o.Books
        };
        
        var order = _unitOfWork.OrderRepository.GetById(id,includes);
        var booksIds = order.Books.Select(b => b.Id);
        var bookOrderQuantities = _unitOfWork
            .BookOrderRepository
            .FindAll(o => booksIds.Contains(o.BooksId) && order.Id == o.OrderId)
            .Select(o => o.Quantity);
        
        var result = _mapper.Map<OrderDto>(order);
        result.Quantities = bookOrderQuantities;
        return Ok(result);
    }
}