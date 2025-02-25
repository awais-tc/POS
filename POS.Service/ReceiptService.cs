using POS.Core.Dtos;
using POS.Core.Repository;
using POS.Core.Service;

public class ReceiptService : IReceiptService
{
    private readonly IReceiptRepository _receiptRepository;

    public ReceiptService(IReceiptRepository receiptRepository)
    {
        _receiptRepository = receiptRepository;
    }

    public async Task<ReceiptDto> GenerateReceiptAsync(SaleDto saleDto)
    {
        var receipt = new ReceiptDto
        {
            ReceiptId = Guid.NewGuid().ToString(),
            SaleId = saleDto.SaleId,
            GeneratedDate = DateTime.UtcNow,
            ReceiptContent = GenerateReceiptContent(saleDto),
            Sale = saleDto
        };

        return await _receiptRepository.AddAsync(receipt);
    }

    public async Task<ReceiptDto?> GetReceiptBySaleIdAsync(string saleId)
    {
        return await _receiptRepository.GetBySaleIdAsync(saleId);
    }

    public async Task<List<ReceiptDto>> GetAllReceiptsAsync()
    {
        return await _receiptRepository.GetAllAsync();
    }

    private string GenerateReceiptContent(SaleDto saleDto)
    {
        return $"Receipt ID: {Guid.NewGuid()}\nSale ID: {saleDto.SaleId}\n" +
               $"Total Amount: {saleDto.TotalAmount}\nDate: {saleDto.SaleDate}\n" +
               $"Items Sold: {saleDto.SaleItems.Count}";
    }
}
