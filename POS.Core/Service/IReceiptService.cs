using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Core.Dtos;

namespace POS.Core.Service
{
    public interface IReceiptRepository
    {
        Task<ReceiptDto> GenerateReceiptAsync(SaleDto sale);

    }
}
