using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Core.Dtos;

namespace POS.Core.Service
{
    internal interface ISaleItemService
    {
        Task AddSaleItemAsync(SaleItemDto saleItemDto);
        Task<SaleItemDto> GetSaleItemAsync(string saleItemId);
        Task<IEnumerable<SaleItemDto>> GetSaleItemsAsync();
        Task UpdateSaleItemAsync(SaleItemDto saleItemDto);
        Task DeleteSaleItemAsync(string saleItemId);
    }
}
