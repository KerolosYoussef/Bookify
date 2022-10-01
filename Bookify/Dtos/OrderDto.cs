using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bookify.Models;

namespace Bookify.Dtos;

public class OrderDto
{
    public OrderDto()
    {
        Date = DateTime.Now;
    }
    
    public int Id { get; set; }
    [Required]
    public string CustomerId { get; set; }
    [Required]
    public string CustomerFirstName { get; set; }
    [Required]
    public string CustomerLastName { get; set; }
    [Required]
    public string CustomerEmail { get; set; }
    [Required]
    public string customerPhone { get; set; }
    [Required]
    public string CustomerCountry { get; set; }
    [Required]
    public string CustomerAddress { get; set; }
    [Required]
    public string CustomerPostalCode { get; set; }
    [Required]
    public double SubTotal { get; set; }
    [Required]
    public double Tax { get; set; }
    [Required]
    public double Total { get; set; }
    public string BasketId { get; set; }
    
    public DateTime Date { get; set; }
    public string Status { get; set; }
    
    public virtual ICollection<BookDto> Books { get; set; }
    public string Reference { get; set; }
    public IEnumerable<int> Quantities { get; set; }

}