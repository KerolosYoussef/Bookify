using System.ComponentModel.DataAnnotations;

namespace Bookify.Models;

public class Order : BaseModel
{
    public Order()
    {
        Status = "Pending";
    }
    public string CustomerId { get; set; }
    public string CustomerEmail { get; set; }

    public string CustomerPhone { get; set; }
    public string CustomerFirstName { get; set; }
    public string CustomerLastName { get; set; }
    public string CustomerCountry { get; set; }
    public string CustomerPostalCode { get; set; }
    public string CustomerAddress { get; set; }
    public double SubTotal { get; set; }
    public double Tax { get; set; }
    public double Total { get; set; }
    public string Status { get; set; }
    public virtual ICollection<Book> Books { get; set; }
    public DateTime Date { get; set; }
    public string Reference { get; set; }
}