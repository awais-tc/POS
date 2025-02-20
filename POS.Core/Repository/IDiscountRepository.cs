using POS.Core.Dtos;

namespace POS.Core.Repository
{
    public interface IDiscountRepository
    {
        Task<DiscountDto> CreateDiscountAsync(DiscountDto discountDto);
        Task<DiscountDto> GetDiscountAsync(string discountId);
        Task<IEnumerable<DiscountDto>> GetDiscountsAsync();
        Task<DiscountDto> UpdateDiscountAsync(DiscountDto discountDto);
        Task<DiscountDto> DeleteDiscountAsync(string discountId);
    }
}
