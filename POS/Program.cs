using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using POS.Core.Service;
using POS.Service;
using POS.Repository;
using POS.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace POS
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a Host to manage services
            var host = CreateHostBuilder(args).Build();

            // Run database migrations
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<POSDbContext>();
                    Console.WriteLine("Applying migrations...");
                    context.Database.Migrate();
                    Console.WriteLine("Migrations applied successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while migrating the database: {ex.Message}");
                }
            }
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    // Load configuration
                    var configuration = context.Configuration;

                    // Register repository layer (removes direct dependency on DbContext)
                    services.AddRepositoryLayer(configuration);

                    // Register service layer
                    services.AddScoped<IUserService, UserService>();
                    services.AddScoped<ITaxService, TaxService>();
                    services.AddScoped<IProductService, ProductService>();
                    services.AddScoped<ISaleItemService, SaleItemService>();
                    services.AddScoped<IDiscountService, DiscountService>();
                    services.AddScoped<IBarcodeService, BarcodeService>();
                    services.AddScoped<ISaleService, SaleService>();
                    services.AddScoped<IInventoryService, InventoryService>();
                    services.AddScoped<IRoleService, RoleService>();
                    services.AddScoped<IReceiptService, ReceiptService>();
                    services.AddScoped<IPaymentService, PaymentService>();

                    services.AddAutoMapper(typeof(TaxMappingProfile));
                });
    }
}
