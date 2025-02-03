using POS.Core.Dtos;

namespace POS.Core.Service
{
    public interface IBarcodeService
    {
        Task<BarcodeDto> CreateBarcodeAsync(BarcodeDto barcodeDto);
        Task<BarcodeDto> GetBarcodeAsync(string barcodeId);
        Task<IEnumerable<BarcodeDto>> GetBarcodesAsync();
        Task<BarcodeDto> UpdateBarcodeAsync(BarcodeDto barcodeDto);
        Task<BarcodeDto> DeleteBarcodeAsync(string barcodeId);
    }
}
