using POS.Core.Dtos;

namespace POS.Core.Repository
{
    public interface IPaymentRepository
    {
        public void ProcessPayment();
        public void UpdatePaymentStatus(PaymentDto paymentDto);

    }
}
