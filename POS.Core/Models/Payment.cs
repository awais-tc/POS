using System.ComponentModel.DataAnnotations;

public class Payment
{
    [Key]
    public string PaymentId { get; set; } = null!;

    [Required]
    public string SaleId { get; set; } = null!;

    [Required]
    public float Amount { get; set; }

    [Required]
    public DateTime PaymentDate { get; set; }

    [Required, MaxLength(50)]
    public string PaymentType { get; set; } = null!;

    [MaxLength(20)]
    public string PaymentStatus { get; set; } = null!;

    public virtual ICollection<UserPayment> UserPayments { get; set; } = new List<UserPayment>();
}
