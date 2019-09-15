using BillAppDDD.Modules.Bills.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BillAppDDD.Modules.Bills.Infrastructure.Products
{
    internal class ProductEntityConfigurator : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(p => p.Category)
                .WithMany(c => c.Products);

            builder.OwnsOne(p => p.Barcode);
            builder.OwnsOne(p => p.Price);
        }
    }
}
