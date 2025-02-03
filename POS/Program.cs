using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using POS.Repository.Context;

using System;

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
                    services.AddDbContext<POSDbContext>(options =>
                        options.UseSqlServer("Data Source=DESKTOP-KQ5BDOJ\\SQLEXPRESS;Initial Catalog=POS_Updated;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False"));
                });
    }
}