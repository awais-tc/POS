using AutoMapper;
using Microsoft.EntityFrameworkCore;
using POS.Core.Dtos;
using POS.Core.Repository;
using POS.Repository.Context;

namespace POS.Repository
{
    public class TaxRepository : ITaxRepository
    {
        private readonly POSDbContext _context;
        private readonly IMapper _mapper;

        public TaxRepository(POSDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TaxDto> GetTaxByRegionAsync(string region)
        {
            var tax = await _context.Taxes.FirstOrDefaultAsync(t => t.Region == region);
            return _mapper.Map<TaxDto>(tax);
        }

        public async Task<List<TaxDto>> GetAllTaxesAsync()
        {
            var taxes = await _context.Taxes.ToListAsync();
            return _mapper.Map<List<TaxDto>>(taxes);
        }

        public async Task<TaxDto> AddTaxAsync(TaxDto taxDto)
        {
            var tax = _mapper.Map<Tax>(taxDto);
            await _context.Taxes.AddAsync(tax);
            await _context.SaveChangesAsync();
            return _mapper.Map<TaxDto>(tax);
        }

        public async Task<TaxDto> UpdateTaxAsync(TaxDto taxDto)
        {
            var tax = await _context.Taxes.FindAsync(taxDto.TaxId);
            if (tax == null) return null!;

            _mapper.Map(taxDto, tax);
            _context.Taxes.Update(tax);
            await _context.SaveChangesAsync();

            return _mapper.Map<TaxDto>(tax);
        }

        public async Task<bool> DeleteTaxAsync(string taxId)
        {
            var tax = await _context.Taxes.FindAsync(taxId);
            if (tax == null) return false;

            _context.Taxes.Remove(tax);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
