using BillAppDDD.Modules.Bills.Domain.Bills;
using BillAppDDD.Modules.Bills.Domain.Products;
using BillAppDDD.Modules.Bills.Domain.Stores;
using BillAppDDD.Modules.Bills.Infrastructure.Bills;
using BillAppDDD.Modules.Bills.Infrastructure.Products;
using BillAppDDD.Modules.Bills.Infrastructure.Purchases;
using Microsoft.EntityFrameworkCore;

namespace Modules.Bills.Infrastructure
{
    public class BillContext : DbContext
    {
        public BillContext(DbContextOptions<BillContext> options) : base(options)
        {
        }

        public DbSet<Bill> Bills { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Store> Stores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BillEntityConfigurator());
            modelBuilder.ApplyConfiguration(new PurchaseEntityConfigurator());
            modelBuilder.ApplyConfiguration(new ProductEntityConfigurator());
            modelBuilder.ApplyConfiguration(new StoreEntityConfigurator());
        }
    }
}
