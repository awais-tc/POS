using POS.Core.Dtos;
using POS.Core.Repository;
using POS.Core.Service;

public class BarcodeService : IBarcodeService
{
    private readonly IBarcodeRepository _barcodeRepository;

    public BarcodeService(IBarcodeRepository barcodeRepository)
    {
        _barcodeRepository = barcodeRepository;
    }

    public async Task<BarcodeDto> CreateBarcodeAsync(BarcodeDto barcodeDto)
    {
        return await _barcodeRepository.CreateBarcodeAsync(barcodeDto);
    }

    public async Task<BarcodeDto> GetBarcodeAsync(string barcodeId)
    {
        return await _barcodeRepository.GetBarcodeAsync(barcodeId);
    }

    public async Task<IEnumerable<BarcodeDto>> GetBarcodesAsync()
    {
        return await _barcodeRepository.GetBarcodesAsync();
    }

    public async Task<BarcodeDto> UpdateBarcodeAsync(BarcodeDto barcodeDto)
    {
        return await _barcodeRepository.UpdateBarcodeAsync(barcodeDto);
    }

    public async Task<bool> DeleteBarcodeAsync(string barcodeId)
    {
        return await _barcodeRepository.DeleteBarcodeAsync(barcodeId);
    }

    public async Task<BarcodeDto> GetBarcodeByProductIdAsync(string productId)
    {
        return await _barcodeRepository.GetBarcodeByProductIdAsync(productId);
    }
}
