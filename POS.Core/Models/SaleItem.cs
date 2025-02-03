using POS.Core.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class SaleItem
{
    [Key]
    public string SaleItemId { get; set; } = null!;

    [Required]
    public string SaleId { get; set; } = null!;

    [Required]
    public string ProductId { get; set; } = null!;

    public int Quantity { get; set; }

    public float Price { get; set; }

    public string? TaxId { get; set; }

    [ForeignKey(nameof(SaleId))]
    public virtual Sale Sale { get; set; } = null!;

    [ForeignKey(nameof(ProductId))]
    public virtual Product Product { get; set; } = null!;

    [ForeignKey(nameof(TaxId))]
    public virtual Tax? Tax { get; set; }
}
