
using POS.Core.Dtos;
using System.Threading.Tasks;
using POS.Core.Repository;
using POS.Core.Service;

namespace POS.Service
{
    public class TaxService : ITaxService
    {
        private readonly ITaxRepository _taxRepository;

        public TaxService(ITaxRepository taxRepository)
        {
            _taxRepository = taxRepository;
        }

        public double CalculateTax(double amount, double taxRate)
        {
            if (amount < 0 || taxRate < 0)
                throw new ArgumentException("Amount and tax rate must be non-negative");

            return amount * (taxRate / 100);
        }

        public async Task<TaxDto> GetTaxByRegionAsync(string region)
        {
            return await _taxRepository.GetTaxByRegionAsync(region);
        }
    }
}
