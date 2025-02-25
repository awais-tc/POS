using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using POS.Core.Repository;
using POS.Repository.Context;

namespace POS.Repository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositoryLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<POSDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Data Source=DESKTOP-J5IS95J\\SQLEXPRESS;Initial Catalog=POS;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False")));

            // Register repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITaxRepository, TaxRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ISaleItemRepository, SaleItemRepository>();
            services.AddScoped<IDiscountRepository, DiscountRepository>();
            services.AddScoped<IBarcodeRepository, BarcodeRepository>();
            services.AddScoped<ISaleRepository, SaleRepository>();
            services.AddScoped<IInventoryRepository, InventoryRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IReceiptRepository, ReceiptRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();

            return services;
        }
    }
}
