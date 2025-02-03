using System;
using System.Collections.Generic;

namespace POS.Core.Dtos;

public partial class ReceiptDto
{
    public string ReceiptId { get; set; } = null!;

    public string SaleId { get; set; } = null!;

    public DateTime GeneratedDate { get; set; }

    public string ReceiptContent { get; set; } = null!;

    public virtual SaleDto Sale { get; set; } = null!;
}
