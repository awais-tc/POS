using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Core.Dtos;

namespace POS.Core.Service
{
    public interface IProductService
    {
        public Task<ProductDto> AddProductAsync(ProductDto productDto);
        public Task<ProductDto> UpdateProductAsync(ProductDto productDto);
        public Task<ProductDto> GetProductAsync(string productId);
        public Task<List<ProductDto>> GetAllProductsAsync();
        public Task<ProductDto> DeleteProductAsync(string productId);



    }
}
