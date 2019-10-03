using BillAppDDD.Modules.Bills.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BillAppDDD.Modules.Bills.Infrastructure.Products
{
    internal class ProductEntityConfigurator : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder
                .Property(p=>p.Id)
                .HasConversion(b => b.Value, val => new ProductId(val))
                .HasColumnName("Id")
                .IsRequired();

            builder
                .Property(p => p.Barcode)
                .HasConversion(b => b.Value, val => new ProductBarcode(val))
                .HasColumnName("Barcode_Value");

            builder
                .Property(p => p.Price)
                .HasConversion(b => b.Value, val => new MoneyValue(val))
                .HasColumnName("Price_Value");


            builder.HasOne<ProductCategory>("category")
                .WithMany(c => c.Products)
                .HasForeignKey("CategoryId");

            builder.HasOne<Product>("lastVersion")
                .WithMany()
                .HasForeignKey("LastVersionId");
        }
    }
}
