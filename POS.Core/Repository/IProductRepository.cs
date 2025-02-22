
using POS.Core.Dtos;

namespace POS.Core.Repository
{
    public interface IProductRepository
    {
        Task<Product> AddAsync(Product product);
        Task<Product> UpdateAsync(Product product);
        Task<Product?> GetByIdAsync(string productId);
        Task<List<Product>> GetAllAsync();
        Task<bool> DeleteAsync(Product product);
    }
}
