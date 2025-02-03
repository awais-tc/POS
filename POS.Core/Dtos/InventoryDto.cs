using System;
using System.Collections.Generic;

namespace POS.Core.Dtos;

public partial class InventoryDto
{
    public string InventoryId { get; set; } = null!;

    public string ProductId { get; set; } = null!;

    public int StockQuantity { get; set; }

    public int ReorderLevel { get; set; }

    public DateTime LastRestocked { get; set; }

    public virtual ProductDto Product { get; set; } = null!;
}
