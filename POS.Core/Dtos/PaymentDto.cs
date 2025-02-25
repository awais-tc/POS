using System.ComponentModel.DataAnnotations;
namespace POS.Core.Dtos;
public class PaymentDto
{ 
    public string PaymentId { get; set; } = null!;
    public string SaleId { get; set; } = null!;
    public float Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public string PaymentType { get; set; } = null!;
    public string PaymentStatus { get; set; } = null!;
    public virtual ICollection<UserPaymentDto> UserPayments { get; set; } = new List<UserPaymentDto>();
}
