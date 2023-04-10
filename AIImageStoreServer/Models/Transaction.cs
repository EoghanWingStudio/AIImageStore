using System;
using System.Collections.Generic;

namespace AIImageStoreServer.Models;

public partial class Transaction
{
    public int TransactionId { get; set; }

    public int OrderId { get; set; }

    public DateTime PaymentDate { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
