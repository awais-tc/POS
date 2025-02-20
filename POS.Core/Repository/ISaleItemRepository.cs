
using POS.Core.Dtos;

namespace POS.Core.Repository
{
    internal interface ISaleItemRepository
    {
        Task AddSaleItemAsync(SaleItemDto saleItemDto);
        Task<SaleItemDto> GetSaleItemAsync(string saleItemId);
        Task<IEnumerable<SaleItemDto>> GetSaleItemsAsync();
        Task UpdateSaleItemAsync(SaleItemDto saleItemDto);
        Task DeleteSaleItemAsync(string saleItemId);
    }
}
