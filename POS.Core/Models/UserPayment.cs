using System.ComponentModel.DataAnnotations.Schema;

public class UserPayment
{
    public string UserId { get; set; } = null!;
    public string PaymentId { get; set; } = null!;

    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; } = null!;

    [ForeignKey(nameof(PaymentId))]
    public virtual Payment Payment { get; set; } = null!;
}
