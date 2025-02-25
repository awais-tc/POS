using POS.Core.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using POS.Core.Repository;
using POS.Repository.Context;

namespace POS.Repository
{
    

    public class DiscountRepository : IDiscountRepository
    {
        private readonly POSDbContext _context;

        public DiscountRepository(POSDbContext context)
        {
            _context = context;
        }

        public async Task<DiscountDto> CreateDiscountAsync(DiscountDto discountDto)
        {
            var discount = new Discount
            {
                DiscountId = discountDto.DiscountId,
                Code = discountDto.Code,
                Percentage = discountDto.Percentage,
                StartDate = discountDto.StartDate,
                EndDate = discountDto.EndDate,
                MinPurchaseAmount = discountDto.MinPurchaseAmount
            };

            await _context.Discounts.AddAsync(discount);
            await _context.SaveChangesAsync();
            return discountDto;
        }

        public async Task<DiscountDto> GetDiscountAsync(string discountId)
        {
            var discount = await _context.Discounts
                .FirstOrDefaultAsync(d => d.DiscountId == discountId);

            return discount == null ? null : new DiscountDto
            {
                DiscountId = discount.DiscountId,
                Code = discount.Code,
                Percentage = discount.Percentage,
                StartDate = discount.StartDate,
                EndDate = discount.EndDate,
                MinPurchaseAmount = discount.MinPurchaseAmount
            };
        }

        public async Task<IEnumerable<DiscountDto>> GetDiscountsAsync()
        {
            return await _context.Discounts
                .Select(d => new DiscountDto
                {
                    DiscountId = d.DiscountId,
                    Code = d.Code,
                    Percentage = d.Percentage,
                    StartDate = d.StartDate,
                    EndDate = d.EndDate,
                    MinPurchaseAmount = d.MinPurchaseAmount
                }).ToListAsync();
        }

        public async Task<DiscountDto> UpdateDiscountAsync(DiscountDto discountDto)
        {
            var discount = await _context.Discounts.FindAsync(discountDto.DiscountId);
            if (discount == null) return null;

            discount.Code = discountDto.Code;
            discount.Percentage = discountDto.Percentage;
            discount.StartDate = discountDto.StartDate;
            discount.EndDate = discountDto.EndDate;
            discount.MinPurchaseAmount = discountDto.MinPurchaseAmount;

            _context.Discounts.Update(discount);
            await _context.SaveChangesAsync();
            return discountDto;
        }

        public async Task<bool> DeleteDiscountAsync(string discountId)
        {
            var discount = await _context.Discounts.FindAsync(discountId);
            if (discount == null) return false;

            _context.Discounts.Remove(discount);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ApplyDiscountAsync(string discountId, double amount)
        {
            var discount = await _context.Discounts.FindAsync(discountId);
            if (discount == null || discount.StartDate > DateTime.Now || discount.EndDate < DateTime.Now)
                return false; // Discount invalid or expired

            if (amount < discount.MinPurchaseAmount)
                return false; // Doesn't meet the min purchase requirement

            return true; // Discount can be applied
        }
    }

}
