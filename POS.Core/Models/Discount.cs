using System.ComponentModel.DataAnnotations;

public class Discount
{
    [Key]
    public string DiscountId { get; set; } = null!;

    [Required]
    public string Code { get; set; } = null!;

    public float Percentage { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public float MinPurchaseAmount { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
