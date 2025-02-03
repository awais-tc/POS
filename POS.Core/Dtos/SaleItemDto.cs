
namespace POS.Core.Dtos;
public class SaleItemDto
{
    
    public string SaleItemId { get; set; } = null!;

    
    public string SaleId { get; set; } = null!;

    
    public string ProductId { get; set; } = null!;

    public int Quantity { get; set; }

    public float Price { get; set; }

    public string? TaxId { get; set; }

    
    public virtual SaleDto Sale { get; set; } = null!;

    
    public virtual ProductDto Product { get; set; } = null!;

    public virtual TaxDto? Tax { get; set; }
}
