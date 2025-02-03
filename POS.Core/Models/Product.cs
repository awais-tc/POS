using System.ComponentModel.DataAnnotations;

public class Product
{
    [Key]
    public string ProductId { get; set; } = null!;

    [Required, MaxLength(100)]
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public float Price { get; set; }

    public string? Category { get; set; }

    public int StockQuantity { get; set; }

    public virtual ICollection<SaleItem> SaleItems { get; set; } = new List<SaleItem>();
}
