using POS.Core.Dtos;
using POS.Core.Repository;
using POS.Core.Service;

public class PaymentService : IPaymentService
{
    private readonly IPaymentRepository _paymentRepository;

    public PaymentService(IPaymentRepository paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }

    public async Task<PaymentDto> ProcessPaymentAsync(PaymentDto paymentDto)
    {
        // Validate PaymentDto
        if (paymentDto == null) throw new ArgumentNullException(nameof(paymentDto));

        // Business logic to process payment (e.g., API calls to payment gateways)
        paymentDto.PaymentStatus = "Completed";
        paymentDto.PaymentDate = DateTime.UtcNow;

        return await _paymentRepository.AddAsync(paymentDto);
    }

    public async Task UpdatePaymentStatusAsync(PaymentDto paymentDto)
    {
        if (paymentDto == null) throw new ArgumentNullException(nameof(paymentDto));

        await _paymentRepository.UpdateAsync(paymentDto);
    }

    public async Task<PaymentDto?> GetPaymentByIdAsync(string paymentId)
    {
        return await _paymentRepository.GetByIdAsync(paymentId);
    }

    public async Task<List<PaymentDto>> GetAllPaymentsAsync()
    {
        return await _paymentRepository.GetAllAsync();
    }
}
