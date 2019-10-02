using BillAppDDD.Modules.Bills.Domain.Bills;
using BillAppDDD.Modules.Bills.Domain.Stores;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BillAppDDD.Modules.Bills.Infrastructure.Bills
{
    internal class StoreEntityConfigurator : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder
                .Property(b => b.Id)
                .HasConversion(b => b.Value, val => new StoreId(val))
                .HasColumnName("Id")
                .IsRequired();

            builder.Property<string>("name").HasColumnName("Name");
            builder.Property<string>("logoImagePath").HasColumnName("LogoImagePath");

            builder.Metadata.FindNavigation(nameof(Store.Bills)).SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
