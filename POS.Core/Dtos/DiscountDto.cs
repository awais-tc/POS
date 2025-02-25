using System.ComponentModel.DataAnnotations;
namespace POS.Core.Dtos;
public class DiscountDto
{
    public string DiscountId { get; set; } = null!;
    public string Code { get; set; } = null!;
    public float Percentage { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public float MinPurchaseAmount { get; set; }
    public virtual ICollection<SaleDto> Sales { get; set; } = new List<SaleDto>();
}
