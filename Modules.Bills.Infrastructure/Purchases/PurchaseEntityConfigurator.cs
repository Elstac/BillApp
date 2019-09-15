using BillAppDDD.Modules.Bills.Domain.Bills;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BillAppDDD.Modules.Bills.Infrastructure.Purchases
{
    internal class PurchaseEntityConfigurator : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.HasKey(p => new { p.BillId, p.ProductId });

            builder.HasOne(p => p.Bill)
                .WithMany(b => b.Purchases);
        }
    }
}
