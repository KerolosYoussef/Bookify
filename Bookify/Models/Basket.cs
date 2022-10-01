namespace Bookify.Models;

public class Basket
{
    public Basket()
    {
    }

    public string Id { get; set; }

    public virtual ICollection<BasketItem> BasketItems { get; set; }
}