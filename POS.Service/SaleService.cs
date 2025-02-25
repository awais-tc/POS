using POS.Core.Dtos;
using POS.Core.Repository;
using POS.Core.Service;

public class SaleService : ISaleService
{
    private readonly ISaleRepository _saleRepository;
    private readonly IDiscountRepository _discountRepository;
    private readonly ITaxRepository _taxRepository;
    private readonly IProductRepository _productRepository;

    public SaleService(
        ISaleRepository saleRepository,
        IDiscountRepository discountRepository,
        ITaxRepository taxRepository,
        IProductRepository productRepository)
    {
        _saleRepository = saleRepository;
        _discountRepository = discountRepository;
        _taxRepository = taxRepository;
        _productRepository = productRepository;
    }

    public async Task<ReceiptDto> CreateSaleAsync(SaleDto saleDto)
    {
        if (saleDto == null || saleDto.SaleItems.Count == 0)
            throw new ArgumentException("Invalid sale details.");

        double totalAmount = 0;

        foreach (var item in saleDto.SaleItems)
        {
            var product = await _productRepository.GetByIdAsync(item.ProductId);
            if (product == null || product.StockQuantity < item.Quantity)
                throw new InvalidOperationException($"Product {item.ProductId} is out of stock.");

            totalAmount += item.Quantity * product.Price;
        }

        // Apply discount if available
        if (!string.IsNullOrEmpty(saleDto.DiscountId))
        {
            var discount = await _discountRepository.GetDiscountAsync(saleDto.DiscountId);
            if (discount != null)
                totalAmount -= (totalAmount * discount.Percentage / 100);
        }

        // Apply tax if applicable
        if (!string.IsNullOrEmpty(saleDto.TaxId))
        {
            var tax = await _taxRepository.GetTaxByRegionAsync(saleDto.TaxId);
            if (tax != null)
                totalAmount += (totalAmount * tax.TaxPercentage / 100);
        }

        // Save sale
        saleDto.TotalAmount = (float)totalAmount;
        var savedSale = await _saleRepository.AddAsync(saleDto);

        return new ReceiptDto
        {
            SaleId = savedSale.SaleId,
            GeneratedDate = savedSale.SaleDate
        };
    }

    public async Task<SaleDto?> GetSaleAsync(string saleId)
    {
        return await _saleRepository.GetByIdAsync(saleId);
    }

    public async Task<IEnumerable<SaleDto>> GetAllSalesAsync()
    {
        return await _saleRepository.GetAllAsync();
    }
}
