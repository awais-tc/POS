
using POS.Core.Dtos;

namespace POS.Core.Repository
{
    public interface ISaleRepository
    {
        Task<ReceiptDto> CreateSaleAsync(SaleDto saleDto);

    }
}
