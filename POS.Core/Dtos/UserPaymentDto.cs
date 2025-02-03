
namespace POS.Core.Dtos;
public class UserPaymentDto
{
    public string UserId { get; set; } = null!;
    public string PaymentId { get; set; } = null!;

    
    public virtual UserDto User { get; set; } = null!;

    public virtual PaymentDto Payment { get; set; } = null!;
}
