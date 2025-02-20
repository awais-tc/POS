
using POS.Core.Dtos;

namespace POS.Core.Repository
{
    public interface IProductRepository
    {
        public Task<ProductDto> AddProductAsync(ProductDto productDto);
        public Task<ProductDto> UpdateProductAsync(ProductDto productDto);
        public Task<ProductDto> GetProductAsync(string productId);
        public Task<List<ProductDto>> GetAllProductsAsync();
        public Task<ProductDto> DeleteProductAsync(string productId);
    }
}
