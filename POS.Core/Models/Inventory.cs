using System;
using System.Collections.Generic;

namespace POS.Core.Models;

public partial class Inventory
{
    public string InventoryId { get; set; } = null!;

    public string ProductId { get; set; } = null!;

    public int StockQuantity { get; set; }

    public int ReorderLevel { get; set; }

    public DateTime LastRestocked { get; set; }

    public virtual Product Product { get; set; } = null!;
}
