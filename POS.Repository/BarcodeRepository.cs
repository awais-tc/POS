using Microsoft.EntityFrameworkCore;
using POS.Core.Dtos;
using POS.Core.Repository;
using POS.Repository.Context;

namespace POS.Repository
{
    public class BarcodeRepository : IBarcodeRepository
    {
        private readonly POSDbContext _context;

        public BarcodeRepository(POSDbContext context)
        {
            _context = context;
        }

        public async Task<BarcodeDto> CreateBarcodeAsync(BarcodeDto barcodeDto)
        {
            var barcode = new Barcode
            {
                BarcodeId = barcodeDto.BarcodeId,
                ProductId = barcodeDto.ProductId,
                BarcodeNumber = barcodeDto.BarcodeNumber
            };

            await _context.Barcodes.AddAsync(barcode);
            await _context.SaveChangesAsync();
            return barcodeDto;
        }

        public async Task<BarcodeDto> GetBarcodeAsync(string barcodeId)
        {
            var barcode = await _context.Barcodes.FindAsync(barcodeId);
            return barcode == null ? null : new BarcodeDto
            {
                BarcodeId = barcode.BarcodeId,
                ProductId = barcode.ProductId,
                BarcodeNumber = barcode.BarcodeNumber
            };
        }

        public async Task<IEnumerable<BarcodeDto>> GetBarcodesAsync()
        {
            return await _context.Barcodes
                .Select(barcode => new BarcodeDto
                {
                    BarcodeId = barcode.BarcodeId,
                    ProductId = barcode.ProductId,
                    BarcodeNumber = barcode.BarcodeNumber
                })
                .ToListAsync();
        }

        public async Task<BarcodeDto> UpdateBarcodeAsync(BarcodeDto barcodeDto)
        {
            var barcode = await _context.Barcodes.FindAsync(barcodeDto.BarcodeId);
            if (barcode == null) return null;

            barcode.BarcodeNumber = barcodeDto.BarcodeNumber;
            _context.Barcodes.Update(barcode);
            await _context.SaveChangesAsync();

            return barcodeDto;
        }

        public async Task<bool> DeleteBarcodeAsync(string barcodeId)
        {
            var barcode = await _context.Barcodes.FindAsync(barcodeId);
            if (barcode == null) return false;

            _context.Barcodes.Remove(barcode);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<BarcodeDto> GetBarcodeByProductIdAsync(string productId)
        {
            var barcode = await _context.Barcodes.FirstOrDefaultAsync(b => b.ProductId == productId);
            return barcode == null ? null : new BarcodeDto
            {
                BarcodeId = barcode.BarcodeId,
                ProductId = barcode.ProductId,
                BarcodeNumber = barcode.BarcodeNumber
            };
        }
    }
}