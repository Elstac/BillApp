using BillAppDDD.BuildingBlocks.Domain;
using Microsoft.EntityFrameworkCore;
using URF.Core.EF;

namespace BillAppDDD.Modules.Bills.Infrastructure
{
    public class ExtendedRepository<TEntity> : Repository<TEntity>, IExtendedRepository<TEntity> where TEntity : class, IAggregateRoot 
    {
        public ExtendedRepository(DbContext context) : base(context)
        {
        }

        public void InsertAggregate(TEntity aggregetRoot)
        {
            Set.Add(aggregetRoot);
        }
    }
}
