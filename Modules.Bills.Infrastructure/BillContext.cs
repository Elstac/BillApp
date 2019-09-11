using BillAppDDD.Modules.Bills.Domain.Bills;
using Microsoft.EntityFrameworkCore;

namespace Modules.Bills.Infrastructure
{
    public class BillContext : DbContext
    {
        public BillContext(DbContextOptions<BillContext> options) : base(options)
        {
        }

        public DbSet<Bill> Bills { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
