using Microsoft.EntityFrameworkCore;
using POS.Core.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using POS.Core.Repository;
using POS.Repository.Context;

public class SaleItemRepository : ISaleItemRepository
{
    private readonly POSDbContext _context;

    public SaleItemRepository(POSDbContext context)
    {
        _context = context;
    }

    public async Task AddSaleItemAsync(SaleItemDto saleItemDto)
    {
        var saleItem = new SaleItem
        {
            SaleItemId = saleItemDto.SaleItemId,
            SaleId = saleItemDto.SaleId,
            ProductId = saleItemDto.ProductId,
            Quantity = saleItemDto.Quantity,
            Price = saleItemDto.Price,
            TaxId = saleItemDto.TaxId
        };

        await _context.SaleItems.AddAsync(saleItem);
        await _context.SaveChangesAsync();
    }

    public async Task<SaleItemDto> GetSaleItemAsync(string saleItemId)
    {
        var saleItem = await _context.SaleItems
            .Include(s => s.Product)
            .Include(s => s.Sale)
            .Include(s => s.Tax)
            .FirstOrDefaultAsync(s => s.SaleItemId == saleItemId);

        if (saleItem == null)
            return null;

        return new SaleItemDto
        {
            SaleItemId = saleItem.SaleItemId,
            SaleId = saleItem.SaleId,
            ProductId = saleItem.ProductId,
            Quantity = saleItem.Quantity,
            Price = saleItem.Price,
            TaxId = saleItem.TaxId,
            Product = new ProductDto
            {
                ProductId = saleItem.Product.ProductId,
                Name = saleItem.Product.Name,
                Description = saleItem.Product.Description,
                Price = saleItem.Product.Price,
                Category = saleItem.Product.Category,
                StockQuantity = saleItem.Product.StockQuantity
            },
            Sale = new SaleDto
            {
                SaleId = saleItem.Sale.SaleId,
                SaleDate = saleItem.Sale.SaleDate,
                TotalAmount = saleItem.Sale.TotalAmount,
                UserId = saleItem.Sale.UserId
            },
            Tax = saleItem.Tax != null
                ? new TaxDto
                {
                    TaxId = saleItem.Tax.TaxId,
                    TaxPercentage = saleItem.Tax.TaxPercentage,
                    Region = saleItem.Tax.Region
                }
                : null
        };
    }

    public async Task<IEnumerable<SaleItemDto>> GetSaleItemsAsync()
    {
        var saleItems = await _context.SaleItems
            .Include(s => s.Product)
            .Include(s => s.Sale)
            .Include(s => s.Tax)
            .ToListAsync();

        return saleItems.Select(s => new SaleItemDto
        {
            SaleItemId = s.SaleItemId,
            SaleId = s.SaleId,
            ProductId = s.ProductId,
            Quantity = s.Quantity,
            Price = s.Price,
            TaxId = s.TaxId,
            Product = new ProductDto
            {
                ProductId = s.Product.ProductId,
                Name = s.Product.Name,
                Description = s.Product.Description,
                Price = s.Product.Price,
                Category = s.Product.Category,
                StockQuantity = s.Product.StockQuantity
            },
            Sale = new SaleDto
            {
                SaleId = s.Sale.SaleId,
                SaleDate = s.Sale.SaleDate,
                TotalAmount = s.Sale.TotalAmount,
                UserId = s.Sale.UserId
            },
            Tax = s.Tax != null
                ? new TaxDto
                {
                    TaxId = s.Tax.TaxId,
                    TaxPercentage = s.Tax.TaxPercentage,
                    Region = s.Tax.Region
                }
                : null
        }).ToList();
    }

    public async Task UpdateSaleItemAsync(SaleItemDto saleItemDto)
    {
        var saleItem = await _context.SaleItems.FindAsync(saleItemDto.SaleItemId);

        if (saleItem != null)
        {
            saleItem.SaleId = saleItemDto.SaleId;
            saleItem.ProductId = saleItemDto.ProductId;
            saleItem.Quantity = saleItemDto.Quantity;
            saleItem.Price = saleItemDto.Price;
            saleItem.TaxId = saleItemDto.TaxId;

            _context.SaleItems.Update(saleItem);
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteSaleItemAsync(string saleItemId)
    {
        var saleItem = await _context.SaleItems.FindAsync(saleItemId);

        if (saleItem != null)
        {
            _context.SaleItems.Remove(saleItem);
            await _context.SaveChangesAsync();
        }
    }
}
