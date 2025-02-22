
namespace POS.Core.Dtos;
public class SaleDto
{
    
    public string SaleId { get; set; } = null!;
    public string UserId { get; set; } = null!;
    public DateTime SaleDate { get; set; }
    public float TotalAmount { get; set; }
    public string? DiscountId { get; set; }
    public string? TaxId { get; set; }
    public virtual UserDto User { get; set; } = null!;
    public virtual DiscountDto? Discount { get; set; }
    public virtual TaxDto? Tax { get; set; }
    public virtual ICollection<SaleItemDto> SaleItems { get; set; } = new List<SaleItemDto>();
}
