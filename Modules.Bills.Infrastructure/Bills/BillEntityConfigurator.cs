using BillAppDDD.Modules.Bills.Domain.Bills;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace BillAppDDD.Modules.Bills.Infrastructure.Bills
{
    internal class BillEntityConfigurator : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property<DateTime>("date").HasColumnName("Date");

            builder.Metadata.FindNavigation(nameof(Bill.Purchases)).SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
