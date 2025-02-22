using System.ComponentModel.DataAnnotations;
namespace POS.Core.Dtos;
public class ProductDto
{
   
    public string ProductId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public float Price { get; set; }

    public string? Category { get; set; }

    public int StockQuantity { get; set; }

    public virtual ICollection<SaleItemDto> SaleItems { get; set; } = new List<SaleItemDto>();
}
