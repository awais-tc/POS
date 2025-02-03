using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Barcode
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [StringLength(450)]
    public string BarcodeId { get; set; } = null!;

    [Required]
    [StringLength(450)]
    public string ProductId { get; set; } = null!;

    [Required]
    [StringLength(450)]
    public string BarcodeNumber { get; set; } = null!;

    [ForeignKey(nameof(ProductId))]
    public virtual Product Product { get; set; } = null!;
}
