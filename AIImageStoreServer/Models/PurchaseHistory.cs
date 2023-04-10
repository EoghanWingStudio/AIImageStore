using System;
using System.Collections.Generic;

namespace AIImageStoreServer.Models;

public partial class PurchaseHistory
{
    public int UserId { get; set; }

    public int OrderId { get; set; }

    public DateTime PurchaseDate { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
