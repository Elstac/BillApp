using BillAppDDD.Modules.Bills.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BillAppDDD.Modules.Bills.Infrastructure.Products
{
    internal class ProductCategoryEntityConfigurator : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.Property<string>("name").HasColumnName("Name");

            builder
                .Property(b => b.Id)
                .HasConversion(b => b.Value, val => new ProductCategoryId(val))
                .HasColumnName("Id")
                .IsRequired();

            builder.Metadata.FindNavigation(nameof(ProductCategory.Products)).SetPropertyAccessMode(PropertyAccessMode.Field);
            builder.Metadata.FindNavigation(nameof(ProductCategory.Subcategories)).SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
