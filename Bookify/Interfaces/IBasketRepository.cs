using Bookify.Models;

namespace Bookify.Interfaces;

public interface IBasketRepository
{
    Basket GetBasket(string id);
    Basket UpdateBasket(Basket basket);
    void DeleteBasket(string id);
}