using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Core.Dtos;

namespace POS.Core.Service
{
    internal interface ISaleService
    {
        Task<ReceiptDto> CreateSaleAsync(SaleDto saleDto);

    }
}
