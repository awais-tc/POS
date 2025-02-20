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
        Task<InventoryDto> AddInventory(InventoryDto inventoryDto);
        Task<InventoryDto> UpdateInventory(InventoryDto inventoryDto);
        Task<InventoryDto> GetInventory(string inventoryId);
        Task<List<InventoryDto>> GetInventories();
        Task<List<InventoryDto>> GetInventoriesByProductId(string productId);
        Task<bool> DeleteInventory(string inventoryId);
    }
}
