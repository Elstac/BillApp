using AutoMapper;
using BillAppDDD.BuildingBlocks.Infrastructure;
using BillAppDDD.Modules.Bills.Application.Bills.Dto;
using BillAppDDD.Modules.Bills.Application.Stores.Dto;
using Dapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BillAppDDD.Modules.Bills.Application.Stores.GetAllStores
{
    class GetAllStoresQueryHandler : IRequestHandler<GetAllStores, List<StoreDetailsDto>>
    {
        private IDbConnectionFactory dbConnectionFactory;

        public GetAllStoresQueryHandler(IDbConnectionFactory dbConnectionFactory)
        {
            this.dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<List<StoreDetailsDto>> Handle(GetAllStores request, CancellationToken cancellationToken)
        {
            var connection = dbConnectionFactory.GetDbConnection();

            const string sql = "SELECT S.Id, S.Name, B.Id, B.Date " +
                                "FROM Stores S INNER JOIN " +
                                "Bills B ON B.StoreId = S.Id ";

            var storeDictionary = new Dictionary<Guid, StoreDetailsDto>();

            var storeCollection = connection.Query<StoreDetailsDto, BillDto, StoreDetailsDto>(
                sql,
                (store, bill) =>
                {
                    StoreDetailsDto storeEntry;

                    if (!storeDictionary.TryGetValue(store.Id, out storeEntry))
                    {
                        storeEntry = store;
                        storeEntry.Bills = new List<BillDto>();
                        storeDictionary.Add(storeEntry.Id, storeEntry);
                    }

                    storeEntry.Bills.Add(bill);
                    return storeEntry;
                })
                .Distinct()
                .ToList();

            return storeCollection;
        }
    }
}
