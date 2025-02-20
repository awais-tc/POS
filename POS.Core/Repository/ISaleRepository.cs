
using POS.Core.Dtos;

namespace POS.Core.Repository
{
    internal interface ISaleRepository
    {
        Task<ReceiptDto> CreateSaleAsync(SaleDto saleDto);

    }
}
