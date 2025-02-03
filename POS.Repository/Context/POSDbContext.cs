using Microsoft.EntityFrameworkCore;
using POS.Core.Models;
namespace POS.Repository.Context
{
    public class POSDbContext : DbContext
    {
        public POSDbContext(DbContextOptions<POSDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleItem> SaleItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<UserPayment> UserPayments { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Tax> Taxes { get; set; }
        public DbSet<Barcode> Barcodes { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Receipt> Receipts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserPayment>()
                .HasKey(up => new { up.UserId, up.PaymentId });

            modelBuilder.Entity<UserPayment>()
                .HasOne(up => up.User)
                .WithMany(u => u.UserPayments)
                .HasForeignKey(up => up.UserId);

            modelBuilder.Entity<UserPayment>()
                .HasOne(up => up.Payment)
                .WithMany(p => p.UserPayments)
                .HasForeignKey(up => up.PaymentId);
        }
    }
}
