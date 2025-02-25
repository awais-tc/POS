using POS.Core.Dtos;

namespace POS.Core.Repository
{
    public interface IReceiptRepository
    {
        Task<ReceiptDto> AddAsync(ReceiptDto receiptDto);
        Task<ReceiptDto?> GetBySaleIdAsync(string saleId);
        Task<List<ReceiptDto>> GetAllAsync();
    }

}
