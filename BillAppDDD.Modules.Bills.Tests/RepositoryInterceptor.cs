using BillAppDDD.BuildingBlocks.Domain;
using BillAppDDD.Modules.Bills.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using URF.Core.Abstractions;

namespace BillAppDDD.Modules.Bills.Tests
{
    class RepositoryInterceptor<TEntity> : IExtendedRepository<TEntity> where TEntity:class,IAggregateRoot
    {
        public RepositoryInterceptor()
        {
        }

        public TEntity InterceptedEntity { get; set; }

        public void Attach(TEntity item)
        {
            InterceptedEntity = item;
        }

        public void Delete(TEntity item)
        {
            InterceptedEntity = item;
        }

        public Task<bool> DeleteAsync(object[] keyValues, CancellationToken cancellationToken = default)
        {
            return null;
        }

        public Task<bool> DeleteAsync<TKey>(TKey keyValue, CancellationToken cancellationToken = default)
        {
            return null;
        }

        public void Detach(TEntity item)
        {

        }

        public Task<bool> ExistsAsync(object[] keyValues, CancellationToken cancellationToken = default)
        {
            return null;
        }

        public Task<bool> ExistsAsync<TKey>(TKey keyValue, CancellationToken cancellationToken = default)
        {
            return null;
        }

        public Task<TEntity> FindAsync(object[] keyValues, CancellationToken cancellationToken = default)
        {
            return null;
        }

        public Task<TEntity> FindAsync<TKey>(TKey keyValue, CancellationToken cancellationToken = default)
        {
            return null;
        }

        public void Insert(TEntity item)
        {
            InterceptedEntity = item;
        }

        public void InsertAggregate(TEntity aggregetRoot)
        {
            InterceptedEntity = aggregetRoot;
        }

        public async Task LoadPropertyAsync(TEntity item, Expression<Func<TEntity, object>> property, CancellationToken cancellationToken = default)
        {
            
        }

        public IQuery<TEntity> Query()
        {
            return null;
        }

        public IQueryable<TEntity> Queryable()
        {
            return null;
        }

        public IQueryable<TEntity> QueryableSql(string sql, params object[] parameters)
        {
            return null;
        }

        public void Update(TEntity item)
        {
            InterceptedEntity = item;
        }
    }
}
