using POS.Core.Dtos;
using POS.Core.Models;
using POS.Core.Repository;
using POS.Core.Service;


namespace POS.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductDto> AddProductAsync(ProductDto productDto)
        {
            // Map DTO to entity
            var product = new Product
            {
                ProductId = productDto.ProductId,
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                Category = productDto.Category,
                StockQuantity = productDto.StockQuantity
            };

            // Save to the database
            var addedProduct = await _productRepository.AddAsync(product);

            // Map entity back to DTO and return
            return new ProductDto
            {
                ProductId = addedProduct.ProductId,
                Name = addedProduct.Name,
                Description = addedProduct.Description,
                Price = addedProduct.Price,
                Category = addedProduct.Category,
                StockQuantity = addedProduct.StockQuantity
            };
        }

        public async Task<ProductDto> UpdateProductAsync(ProductDto productDto)
        {
            // Check if the product exists
            var existingProduct = await _productRepository.GetByIdAsync(productDto.ProductId);
            if (existingProduct == null)
            {
                throw new Exception("Product not found.");
            }

            // Update entity
            existingProduct.Name = productDto.Name;
            existingProduct.Description = productDto.Description;
            existingProduct.Price = productDto.Price;
            existingProduct.Category = productDto.Category;
            existingProduct.StockQuantity = productDto.StockQuantity;

            // Save changes
            await _productRepository.UpdateAsync(existingProduct);

            // Map entity back to DTO and return
            return new ProductDto
            {
                ProductId = existingProduct.ProductId,
                Name = existingProduct.Name,
                Description = existingProduct.Description,
                Price = existingProduct.Price,
                Category = existingProduct.Category,
                StockQuantity = existingProduct.StockQuantity
            };
        }

        public async Task<ProductDto> GetProductAsync(string productId)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            if (product == null)
            {
                throw new Exception("Product not found.");
            }

            return new ProductDto
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Category = product.Category,
                StockQuantity = product.StockQuantity
            };
        }

        public async Task<List<ProductDto>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllAsync();

            return products.Select(p => new ProductDto
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Category = p.Category,
                StockQuantity = p.StockQuantity
            }).ToList();
        }

        public async Task<ProductDto> DeleteProductAsync(string productId)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            if (product == null)
            {
                throw new Exception("Product not found.");
            }

            await _productRepository.DeleteAsync(product);

            return new ProductDto
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Category = product.Category,
                StockQuantity = product.StockQuantity
            };
        }
    }
}
