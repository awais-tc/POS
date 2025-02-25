using POS.Core.Dtos;
using Microsoft.EntityFrameworkCore;
using POS.Core.Repository;
using POS.Repository.Context;


public class SaleRepository : ISaleRepository
{
    private readonly POSDbContext _context;

    public SaleRepository(POSDbContext context)
    {
        _context = context;
    }

    public async Task<SaleDto> AddAsync(SaleDto saleDto)
    {
        if (saleDto == null)
            throw new ArgumentNullException(nameof(saleDto));

        var saleEntity = new Sale
        {
            SaleId = saleDto.SaleId,
            UserId = saleDto.UserId,
            SaleDate = saleDto.SaleDate,
            TotalAmount = saleDto.TotalAmount,
            DiscountId = saleDto.DiscountId,
            TaxId = saleDto.TaxId
        };

        _context.Sales.Add(saleEntity);
        await _context.SaveChangesAsync();

        return new SaleDto
        {
            SaleId = saleEntity.SaleId,
            UserId = saleEntity.UserId,
            SaleDate = saleEntity.SaleDate,
            TotalAmount = saleEntity.TotalAmount,
            DiscountId = saleEntity.DiscountId,
            TaxId = saleEntity.TaxId
        };
    }

    public async Task<SaleDto?> GetByIdAsync(string saleId)
    {
        var saleEntity = await _context.Sales
            .Include(s => s.User)
            .Include(s => s.Discount)
            .Include(s => s.Tax)
            .Include(s => s.SaleItems)
                .ThenInclude(si => si.Product)
            .FirstOrDefaultAsync(s => s.SaleId == saleId);

        if (saleEntity == null)
            return null;

        return new SaleDto
        {
            SaleId = saleEntity.SaleId,
            UserId = saleEntity.UserId,
            SaleDate = saleEntity.SaleDate,
            TotalAmount = saleEntity.TotalAmount,
            DiscountId = saleEntity.DiscountId,
            TaxId = saleEntity.TaxId,
            SaleItems = saleEntity.SaleItems.Select(si => new SaleItemDto
            {
                SaleItemId = si.SaleItemId,
                SaleId = si.SaleId,
                ProductId = si.ProductId,
                Quantity = si.Quantity,
                Price = si.Price
            }).ToList()
        };
    }

    public async Task<List<SaleDto>> GetAllAsync()
    {
        var sales = await _context.Sales
            .Include(s => s.User)
            .Include(s => s.Discount)
            .Include(s => s.Tax)
            .Include(s => s.SaleItems)
                .ThenInclude(si => si.Product)
            .ToListAsync();

        return sales.Select(saleEntity => new SaleDto
        {
            SaleId = saleEntity.SaleId,
            UserId = saleEntity.UserId,
            SaleDate = saleEntity.SaleDate,
            TotalAmount = saleEntity.TotalAmount,
            DiscountId = saleEntity.DiscountId,
            TaxId = saleEntity.TaxId,
            SaleItems = saleEntity.SaleItems.Select(si => new SaleItemDto
            {
                SaleItemId = si.SaleItemId,
                SaleId = si.SaleId,
                ProductId = si.ProductId,
                Quantity = si.Quantity,
                Price = si.Price
            }).ToList()
        }).ToList();
    }
}
