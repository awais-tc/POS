using POS.Core.Dtos;
using POS.Core.Repository;
using POS.Core.Service;

public class DiscountService : IDiscountService
{
    private readonly IDiscountRepository _discountRepository;

    public DiscountService(IDiscountRepository discountRepository)
    {
        _discountRepository = discountRepository;
    }

    public async Task CreateDiscountAsync(DiscountDto discountDto)
    {
        if (discountDto == null)
            throw new ArgumentNullException(nameof(discountDto));

        await _discountRepository.CreateDiscountAsync(discountDto);
    }

    public async Task<DiscountDto> GetDiscountAsync(string discountId)
    {
        return await _discountRepository.GetDiscountAsync(discountId);
    }

    public async Task<IEnumerable<DiscountDto>> GetDiscountsAsync()
    {
        return await _discountRepository.GetDiscountsAsync();
    }

    public async Task UpdateDiscountAsync(DiscountDto discountDto)
    {
        if (discountDto == null)
            throw new ArgumentNullException(nameof(discountDto));

        await _discountRepository.UpdateDiscountAsync(discountDto);
    }

    public async Task<bool> DeleteDiscountAsync(string discountId)
    {
        return await _discountRepository.DeleteDiscountAsync(discountId);
    }


    public async Task<bool> ApplyDiscountAsync(string discountId, double amount)
    {
        var discount = await _discountRepository.GetDiscountAsync(discountId);

        if (discount == null)
        {
            Console.WriteLine("Discount not found.");
            return false;
        }

        if (DateTime.UtcNow < discount.StartDate || DateTime.UtcNow > discount.EndDate)
        {
            Console.WriteLine("Discount is not valid at this time.");
            return false;
        }

        if (amount < discount.MinPurchaseAmount)
        {
            Console.WriteLine($"Minimum purchase amount of {discount.MinPurchaseAmount} required.");
            return false;
        }

        double discountedAmount = amount - (amount * (discount.Percentage / 100));
        Console.WriteLine($"Discount applied! New total: {discountedAmount}");
        return true;
    }

    public async Task RemoveDiscountAsync()
    {
        Console.WriteLine("Discount removed (This method needs additional implementation based on business logic).");
        await Task.CompletedTask;
    }
}
