using BillAppDDD.Modules.Bills.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BillAppDDD.Modules.Bills.Infrastructure.Products
{
    internal class ProductEntityConfigurator : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.OwnsOne(p => p.Barcode);
            builder.OwnsOne(p => p.Price);

            builder
                .Property(p=>p.Id)
                .HasConversion(b => b.Value, val => new ProductId(val))
                .HasColumnName("Id")
                .IsRequired();

            builder.HasOne<ProductCategory>("category")
                .WithMany(c => c.Products)
                .HasForeignKey("CategoryId");

            builder.HasOne<Product>("lastVersion")
                .WithMany()
                .HasForeignKey("LastVersionId");
        }
    }
}
