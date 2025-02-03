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
        public void ApplyDiscount(double amount,double rate);
        public void RemoveDiscount();
        public void GetDiscount();
        public void CreateDiscountAsync(DiscountDto discountDto);
        public void UpdateDiscountAsync(DiscountDto discountDto);
        public void DeleteDiscountAsync(string discountId);

    }
}
