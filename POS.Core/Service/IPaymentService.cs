using POS.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Core.Service
{
    public interface IPaymentService
    {
        Task<PaymentDto> ProcessPaymentAsync(PaymentDto paymentDto);
        Task UpdatePaymentStatusAsync(PaymentDto paymentDto);
        Task<PaymentDto?> GetPaymentByIdAsync(string paymentId);
        Task<List<PaymentDto>> GetAllPaymentsAsync();
    }

}
