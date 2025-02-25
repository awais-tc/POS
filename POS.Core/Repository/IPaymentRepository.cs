using POS.Core.Dtos;

namespace POS.Core.Repository
{
    public interface IPaymentRepository
    {
        Task<PaymentDto> AddAsync(PaymentDto paymentDto);
        Task<PaymentDto?> GetByIdAsync(string paymentId);
        Task<List<PaymentDto>> GetAllAsync();
        Task UpdateAsync(PaymentDto paymentDto);
    }

}
