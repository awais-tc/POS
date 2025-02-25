using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Core.Dtos;

namespace POS.Core.Service
{
    public interface ISaleService
    {
        Task<ReceiptDto> CreateSaleAsync(SaleDto saleDto);
        Task<SaleDto> GetSaleAsync(string saleId);
        Task<IEnumerable<SaleDto>> GetAllSalesAsync();

    }
}
