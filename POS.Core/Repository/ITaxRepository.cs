using POS.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Core.Repository
{
    public interface ITaxRepository
    {
        Task<TaxDto> GetTaxByRegionAsync(string region);
        Task<List<TaxDto>> GetAllTaxesAsync();
        Task<TaxDto> AddTaxAsync(TaxDto taxDto);
        Task<TaxDto> UpdateTaxAsync(TaxDto taxDto);
        Task<bool> DeleteTaxAsync(string taxId);
    }
}
