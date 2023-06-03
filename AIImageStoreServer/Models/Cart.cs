using System;
using System.Collections.Generic;

namespace AIImageStoreServer.Models;

public partial class Cart
{
    public int CartId { get; set; }
    public int UserId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public List<Product> Products { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
