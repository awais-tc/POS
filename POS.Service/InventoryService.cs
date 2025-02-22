using POS.Core.Dtos;
using POS.Core.Repository;
using POS.Core.Service;

namespace POS.Service
{
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRepository _inventoryRepository;

        public InventoryService(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        public async Task<InventoryDto> AddInventoryAsync(InventoryDto inventoryDto)
        {
            if (inventoryDto == null)
                throw new ArgumentNullException(nameof(inventoryDto));

            return await _inventoryRepository.AddInventoryAsync(inventoryDto);
        }

        public async Task<InventoryDto> UpdateInventory(InventoryDto inventoryDto)
        {
            if (inventoryDto == null)
                throw new ArgumentNullException(nameof(inventoryDto));

            return await _inventoryRepository.UpdateInventoryAsync(inventoryDto);
        }

        public async Task<InventoryDto> GetInventory(string inventoryId)
        {
            if (string.IsNullOrEmpty(inventoryId))
                throw new ArgumentException("Inventory ID cannot be null or empty", nameof(inventoryId));

            return await _inventoryRepository.GetInventoryAsync(inventoryId);
        }

        public async Task<List<InventoryDto>> GetInventories()
        {
            return await _inventoryRepository.GetAllInventoriesAsync();
        }

        public async Task<List<InventoryDto>> GetInventoriesByProductId(string productId)
        {
            if (string.IsNullOrEmpty(productId))
                throw new ArgumentException("Product ID cannot be null or empty", nameof(productId));

            return await _inventoryRepository.GetInventoriesByProductIdAsync(productId);
        }

        public async Task<bool> DeleteInventory(string inventoryId)
        {
            if (string.IsNullOrEmpty(inventoryId))
                throw new ArgumentException("Inventory ID cannot be null or empty", nameof(inventoryId));

            return await _inventoryRepository.DeleteInventoryAsync(inventoryId);
        }
    }
}
