using POS.Core.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Sale
{
    [Key]
    public string SaleId { get; set; } = null!;

    [Required]
    public string UserId { get; set; } = null!;

    [Required]
    public DateTime SaleDate { get; set; }

    public float TotalAmount { get; set; }

    public string? DiscountId { get; set; }

    public string? TaxId { get; set; }

    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; } = null!;

    [ForeignKey(nameof(DiscountId))]
    public virtual Discount? Discount { get; set; }

    [ForeignKey(nameof(TaxId))]
    public virtual Tax? Tax { get; set; }

    public virtual ICollection<SaleItem> SaleItems { get; set; } = new List<SaleItem>();
}
