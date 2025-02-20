using POS.Core.Dtos;

namespace POS.Core.Repository
{
    public interface IReceiptRepository
    {
        Task<ReceiptDto> GenerateReceiptAsync(SaleDto sale);

    }
}
