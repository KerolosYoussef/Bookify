using Bookify.Helpers;
using Bookify.Interfaces;
using Bookify.Models;
using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.Controllers.Api;

public class BasketController : BaseApiController
{
    private readonly IBasketRepository _basketRepository;

    public BasketController(IBasketRepository basketRepository)
    {
        _basketRepository = basketRepository;
    }

    [HttpGet]
    public ActionResult<Basket> GetBasket(string id)
    {
        var basket = _basketRepository.GetBasket(id);
        return Ok(basket);
    }

    [HttpPost]
    public ActionResult<Basket> UpdateBasket([FromForm] Basket basket)
    {
        var updatedBasket = _basketRepository.UpdateBasket(basket);
        RecurringJob.AddOrUpdate(() => DeleteBasket(basket.Id),Cron.Monthly(DateTime.Today.Day));
        return Ok(updatedBasket);
    }

    [HttpDelete]
    public void DeleteBasket(string id)
    {
        _basketRepository.DeleteBasket(id);
    }
}