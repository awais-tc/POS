using POS.Core.Dtos;

namespace POS.Core.Service
{
    public interface IReceiptService
    {
        Task<ReceiptDto> GenerateReceiptAsync(SaleDto saleDto);
        Task<ReceiptDto?> GetReceiptBySaleIdAsync(string saleId);
        Task<List<ReceiptDto>> GetAllReceiptsAsync();
    }
}
