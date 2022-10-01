using System.Linq.Expressions;
using Bookify.Interfaces;
using Bookify.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookify.Helpers;

public class OrderTransaction
{
    private readonly IUnitOfWork _unitOfWork;

    public OrderTransaction(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public OrderTransaction()
    {
    }

    public void AddQuantityToBookOrder(Order order,ICollection<BasketItem> basketBookItems)
    {
        // Get Book Orders Table
        var bookOrders = _unitOfWork
            .BookOrderRepository
            .FindAll(b => b.OrderId == order.Id, new Expression<Func<BookOrder, object>>[]{b => b.Book})
            .ToList();
        
        bookOrders.ForEach(row =>
        {
            var bookTitle = row.Book.Title;
            row.Quantity = basketBookItems.Single(i => i.BookTitle == bookTitle).Quantity;
        });
        _unitOfWork.BookOrderRepository.UpdateRange(bookOrders);
        _unitOfWork.Complete();
    }
    
    public void DecreaseQuantityFromOrderedBooks(Order order)
    {
        var bookOrders = _unitOfWork
            .BookOrderRepository
            .FindAll(
                b => b.OrderId == order.Id,
                null, 
                null,
                bo => bo.Include(b => b.Book).ThenInclude(b => b.BookSoldCopies))
            .ToList();
        bookOrders.ForEach(row =>
        {
            row.Book.NumberOfCopies -= row.Quantity;
            row.Book.BookSoldCopies.SoldCopies += row.Quantity;
        });
        _unitOfWork.BookOrderRepository.UpdateRange(bookOrders);
        _unitOfWork.Complete();
    }
}