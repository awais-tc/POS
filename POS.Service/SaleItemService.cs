
using POS.Core.Dtos;
using POS.Core.Repository;
using POS.Core.Service;

namespace POS.Service
{
    public class SaleItemService : ISaleItemService
    {
        private readonly ISaleItemRepository _saleItemRepository;

        public SaleItemService(ISaleItemRepository saleItemRepository)
        {
            _saleItemRepository = saleItemRepository;
        }

        public async Task AddSaleItemAsync(SaleItemDto saleItemDto)
        {
            await _saleItemRepository.AddSaleItemAsync(saleItemDto);
        }

        public async Task<SaleItemDto> GetSaleItemAsync(string saleItemId)
        {
            return await _saleItemRepository.GetSaleItemAsync(saleItemId);
        }

        public async Task<IEnumerable<SaleItemDto>> GetSaleItemsAsync()
        {
            return await _saleItemRepository.GetSaleItemsAsync();
        }

        public async Task UpdateSaleItemAsync(SaleItemDto saleItemDto)
        {
            await _saleItemRepository.UpdateSaleItemAsync(saleItemDto);
        }

        public async Task DeleteSaleItemAsync(string saleItemId)
        {
            await _saleItemRepository.DeleteSaleItemAsync(saleItemId);
        }
    }
}
