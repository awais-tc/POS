
using POS.Core.Dtos;

namespace POS.Core.Repository
{
    public interface ISaleRepository
    {
        Task<SaleDto> AddAsync(SaleDto saleDto);
        Task<SaleDto?> GetByIdAsync(string saleId);
        Task<List<SaleDto>> GetAllAsync();
    }
}
