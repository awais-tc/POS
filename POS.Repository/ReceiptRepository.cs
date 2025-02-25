using Microsoft.EntityFrameworkCore;
using POS.Core.Dtos;
using POS.Core.Models;
using POS.Core.Repository;
using POS.Repository.Context;


public class ReceiptRepository : IReceiptRepository
{
    private readonly POSDbContext _context;

    public ReceiptRepository(POSDbContext context)
    {
        _context = context;
    }

    public async Task<ReceiptDto> AddAsync(ReceiptDto receiptDto)
    {
        var entity = new Receipt
        {
            ReceiptId = receiptDto.ReceiptId,
            SaleId = receiptDto.SaleId,
            GeneratedDate = receiptDto.GeneratedDate,
            ReceiptContent = receiptDto.ReceiptContent
        };

        _context.Receipts.Add(entity);
        await _context.SaveChangesAsync();

        return receiptDto;
    }

    public async Task<ReceiptDto?> GetBySaleIdAsync(string saleId)
    {
        var receipt = await _context.Receipts
            .FirstOrDefaultAsync(r => r.SaleId == saleId);

        return receipt != null ? new ReceiptDto
        {
            ReceiptId = receipt.ReceiptId,
            SaleId = receipt.SaleId,
            GeneratedDate = receipt.GeneratedDate,
            ReceiptContent = receipt.ReceiptContent
        } : null;
    }

    public async Task<List<ReceiptDto>> GetAllAsync()
    {
        return await _context.Receipts
            .Select(r => new ReceiptDto
            {
                ReceiptId = r.ReceiptId,
                SaleId = r.SaleId,
                GeneratedDate = r.GeneratedDate,
                ReceiptContent = r.ReceiptContent
            }).ToListAsync();
    }
}
