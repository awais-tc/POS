using System.ComponentModel.DataAnnotations;

public class Tax
{
    [Key]
    public string TaxId { get; set; } = null!;

    public float TaxPercentage { get; set; }

    public string? Region { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

    public virtual ICollection<SaleItem> SaleItems { get; set; } = new List<SaleItem>();
}
