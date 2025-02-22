using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Core.Dtos;

namespace POS.Core.Repository
{
    public interface IInventoryRepository
    {
        Task<InventoryDto> AddInventoryAsync(InventoryDto inventoryDto);
        Task<InventoryDto> UpdateInventoryAsync(InventoryDto inventoryDto);
        Task<InventoryDto> GetInventoryAsync(string inventoryId);
        Task<List<InventoryDto>> GetAllInventoriesAsync();
        Task<List<InventoryDto>> GetInventoriesByProductIdAsync(string productId);
        Task<bool> DeleteInventoryAsync(string inventoryId);
    }
}
