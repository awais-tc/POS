
namespace POS.Core.Dtos;
public class TaxDto
{
    
    public string TaxId { get; set; } = null!;

    public float TaxPercentage { get; set; }

    public string? Region { get; set; }

    public virtual ICollection<SaleDto> Sales { get; set; } = new List<SaleDto>();

    public virtual ICollection<SaleItemDto> SaleItems { get; set; } = new List<SaleItemDto>();
}
