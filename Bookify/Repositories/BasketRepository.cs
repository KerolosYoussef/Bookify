using Bookify.Data;
using Bookify.Interfaces;
using Bookify.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bookify.Repositories;

public class BasketRepository : IBasketRepository
{
    private readonly ApplicationDbContext _context;

    public BasketRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Basket GetBasket(string id)
    {
        return _context.Baskets.Include(b => b.BasketItems).FirstOrDefault(x => x.Id == id);
    }

    public Basket UpdateBasket(Basket basket)
    {
        var test = basket;
        if (_context.Baskets.Any(b => b.Id == basket.Id))
        {
            var itemsToDelete = _context.BasketItems.Where(b => b.BasketId == basket.Id).ToList();
            _context.BasketItems.RemoveRange(itemsToDelete);
            _context.BasketItems.AddRange(basket.BasketItems);
            _context.SaveChanges();
        }
        else
        {
            _context.Baskets.Add(basket);
        }

        _context.SaveChanges();
        return basket;
    }
    [HttpPost]
    [Route("basket/{id}")]
    public void DeleteBasket(string id)
    {
        var basket = this.GetBasket(id);
        _context.BasketItems.RemoveRange(basket.BasketItems);
        _context.Baskets.Remove(basket);
        _context.SaveChanges();
    }
}