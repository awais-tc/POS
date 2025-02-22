using Microsoft.EntityFrameworkCore;
using POS.Core.Dtos;
using POS.Core.Models;
using POS.Core.Repository;
using POS.Repository.Context;


namespace POS.Repository
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly POSDbContext _context;

        public InventoryRepository(POSDbContext context)
        {
            _context = context;
        }

        public async Task<InventoryDto> AddInventoryAsync(InventoryDto inventoryDto)
        {
            var inventory = new Inventory
            {
                InventoryId = inventoryDto.InventoryId,
                ProductId = inventoryDto.ProductId,
                StockQuantity = inventoryDto.StockQuantity,
                ReorderLevel = inventoryDto.ReorderLevel,
                LastRestocked = inventoryDto.LastRestocked
            };

            await _context.Inventories.AddAsync(inventory);
            await _context.SaveChangesAsync();

            return inventoryDto;
        }

        public async Task<InventoryDto> UpdateInventoryAsync(InventoryDto inventoryDto)
        {
            var inventory = await _context.Inventories.FindAsync(inventoryDto.InventoryId);
            if (inventory == null) return null;

            inventory.ProductId = inventoryDto.ProductId;
            inventory.StockQuantity = inventoryDto.StockQuantity;
            inventory.ReorderLevel = inventoryDto.ReorderLevel;
            inventory.LastRestocked = inventoryDto.LastRestocked;

            _context.Inventories.Update(inventory);
            await _context.SaveChangesAsync();

            return inventoryDto;
        }

        public async Task<InventoryDto> GetInventoryAsync(string inventoryId)
        {
            var inventory = await _context.Inventories
                .Include(i => i.Product)
                .FirstOrDefaultAsync(i => i.InventoryId == inventoryId);

            if (inventory == null) return null;

            return new InventoryDto
            {
                InventoryId = inventory.InventoryId,
                ProductId = inventory.ProductId,
                StockQuantity = inventory.StockQuantity,
                ReorderLevel = inventory.ReorderLevel,
                LastRestocked = inventory.LastRestocked,
                Product = new ProductDto
                {
                    ProductId = inventory.Product.ProductId,
                    Name = inventory.Product.Name,
                    Description = inventory.Product.Description,
                    Price = inventory.Product.Price,
                    Category = inventory.Product.Category,
                    StockQuantity = inventory.Product.StockQuantity
                }
            };
        }

        public async Task<List<InventoryDto>> GetAllInventoriesAsync()
        {
            return await _context.Inventories
                .Include(i => i.Product)
                .Select(i => new InventoryDto
                {
                    InventoryId = i.InventoryId,
                    ProductId = i.ProductId,
                    StockQuantity = i.StockQuantity,
                    ReorderLevel = i.ReorderLevel,
                    LastRestocked = i.LastRestocked,
                    Product = new ProductDto
                    {
                        ProductId = i.Product.ProductId,
                        Name = i.Product.Name,
                        Description = i.Product.Description,
                        Price = i.Product.Price,
                        Category = i.Product.Category,
                        StockQuantity = i.Product.StockQuantity
                    }
                }).ToListAsync();
        }

        public async Task<List<InventoryDto>> GetInventoriesByProductIdAsync(string productId)
        {
            return await _context.Inventories
                .Where(i => i.ProductId == productId)
                .Include(i => i.Product)
                .Select(i => new InventoryDto
                {
                    InventoryId = i.InventoryId,
                    ProductId = i.ProductId,
                    StockQuantity = i.StockQuantity,
                    ReorderLevel = i.ReorderLevel,
                    LastRestocked = i.LastRestocked,
                    Product = new ProductDto
                    {
                        ProductId = i.Product.ProductId,
                        Name = i.Product.Name,
                        Description = i.Product.Description,
                        Price = i.Product.Price,
                        Category = i.Product.Category,
                        StockQuantity = i.Product.StockQuantity
                    }
                }).ToListAsync();
        }

        public async Task<bool> DeleteInventoryAsync(string inventoryId)
        {
            var inventory = await _context.Inventories.FindAsync(inventoryId);
            if (inventory == null) return false;

            _context.Inventories.Remove(inventory);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
