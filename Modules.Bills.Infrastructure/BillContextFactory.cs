using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Modules.Bills.Infrastructure;

namespace BillAppDDD.Modules.Bills.Infrastructure
{
    class BillContextFactory : IDesignTimeDbContextFactory<BillContext>
    {
        public BillContext CreateDbContext(string[] args)
        {
            var opt = new DbContextOptionsBuilder<BillContext>();
            opt.UseSqlServer("Server=.;Database=entityframework;Trusted_Connection=True;MultipleActiveResultSets=true;Database=BillApp.Bills");

            return new BillContext(opt.Options);
        }
    }
}
