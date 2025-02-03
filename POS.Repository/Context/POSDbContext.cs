using Microsoft.EntityFrameworkCore;
using POS.Core.Models;
namespace POS.Repository.Context
{
    public class POSDbContext : DbContext
    {
        public POSDbContext(DbContextOptions<POSDbContext> options) : base(options)
        {
        }

        public DbSet<UserDto> Users { get; set; }
        public DbSet<RoleDto> Roles { get; set; }
        public DbSet<SaleDto> Sales { get; set; }
        public DbSet<SaleItemDto> SaleItems { get; set; }
        public DbSet<ProductDto> Products { get; set; }
        public DbSet<PaymentDto> Payments { get; set; }
        public DbSet<UserPaymentDto> UserPayments { get; set; }
        public DbSet<DiscountDto> Discounts { get; set; }
        public DbSet<TaxDto> Taxes { get; set; }
        public DbSet<BarcodeDto> Barcodes { get; set; }
        public DbSet<InventoryDto> Inventories { get; set; }
        public DbSet<ReceiptDto> Receipts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserPaymentDto>()
                .HasKey(up => new { up.UserId, up.PaymentId });

            modelBuilder.Entity<UserPaymentDto>()
                .HasOne(up => up.User)
                .WithMany(u => u.UserPayments)
                .HasForeignKey(up => up.UserId);

            modelBuilder.Entity<UserPaymentDto>()
                .HasOne(up => up.Payment)
                .WithMany(p => p.UserPayments)
                .HasForeignKey(up => up.PaymentId);
        }
    }
}
