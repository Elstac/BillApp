using BillAppDDD.BuildingBlocks.Domain;
using URF.Core.Abstractions;

namespace BillAppDDD.Modules.Bills.Infrastructure
{
    public interface IExtendedRepository<TEntity>: IRepository<TEntity>where TEntity: class,IAggregateRoot
    {
        void InsertAggregate(TEntity aggregetRoot);
    }
}
