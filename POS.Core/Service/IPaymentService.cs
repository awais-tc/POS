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
        public void ProcessPayment();
        public void UpdatePaymentStatus(PaymentDto paymentDto);

    }
}
