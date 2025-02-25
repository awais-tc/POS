using POS.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Core.Service
{
    public interface IDiscountService
    {
        Task<bool> ApplyDiscountAsync(string discountId, double amount);
        Task RemoveDiscountAsync();
        Task<DiscountDto> GetDiscountAsync(string discountId);
        Task CreateDiscountAsync(DiscountDto discountDto);
        Task UpdateDiscountAsync(DiscountDto discountDto);
    }
}
