using System;
using System.Collections.Generic;

namespace POS.Core.Models;

public partial class Receipt
{
    public string ReceiptId { get; set; } = null!;

    public string SaleId { get; set; } = null!;

    public DateTime GeneratedDate { get; set; }

    public string ReceiptContent { get; set; } = null!;

    public virtual Sale Sale { get; set; } = null!;
}
