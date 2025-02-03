using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace POS.Core.Dtos;
public class BarcodeDto
{
    
    public string BarcodeId { get; set; } = null!;

    
    public string ProductId { get; set; } = null!;

    
    public string BarcodeNumber { get; set; } = null!;

    public virtual ProductDto Product { get; set; } = null!;
}
