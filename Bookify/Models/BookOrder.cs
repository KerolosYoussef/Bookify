﻿namespace Bookify.Models;

public class BookOrder : BaseModel
{
    public int BooksId { get; set; }
    public int OrderId { get; set; }
    public int Quantity { get; set; }

    public virtual Book Book { get; set; }
    public virtual Order Order { get; set; }
}