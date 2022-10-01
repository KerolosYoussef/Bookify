namespace Bookify.Models;

public class BasketItem
{
    public int Id { get; set; }
    public string BasketId { get; set; }
    public string BookTitle { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public string ImagePath { get; set; }
}