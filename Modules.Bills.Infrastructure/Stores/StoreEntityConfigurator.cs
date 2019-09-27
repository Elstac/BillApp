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
            builder.HasKey(s => s.Id);

            builder.Property<string>("name").HasColumnName("Name");
            builder.Property<string>("logoImagePath").HasColumnName("LogoImagePath");

            builder.Metadata.FindNavigation(nameof(Store.Bills)).SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
