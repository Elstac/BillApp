using BillAppDDD.Modules.Bills.Domain.Bills;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BillAppDDD.Modules.Bills.Infrastructure.Bills
{
    internal class BillEntityConfigurator : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder
                .HasOne(b => b.Store)
                .WithMany(s => s.Bills);
                
        }
    }
}
