namespace Bookify.Helpers;

public class ShopFilters : PaginationFilters
{
    public string Search { get; set; } = null;

    public int? Genre { get; set; }
    
    public double Min { get; set; }
    public double Max { get; set; }
}