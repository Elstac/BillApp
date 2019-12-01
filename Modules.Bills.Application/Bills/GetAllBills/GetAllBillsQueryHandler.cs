using AutoMapper;
using BillAppDDD.BuildingBlocks.Application;
using BillAppDDD.BuildingBlocks.Infrastructure;
using BillAppDDD.Modules.Bills.Application.Bills.Dto;
using BillAppDDD.Modules.Bills.Application.Stores.Dto;
using Dapper;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BillAppDDD.Modules.Bills.Application.Bills.GetAllBills
{
    internal class GetAllBillsQueryHandler : IRequestHandler<GetAllBills, List<BillDto>>
    {
        private IDbConnectionFactory dbConnectionFactory;
        private IMapper mapper;
        private IExecutionContextAccessor executionContext;

        public GetAllBillsQueryHandler(
            IDbConnectionFactory dbConnectionFactory,
            IMapper mapper,
            IExecutionContextAccessor executionContext)
        {
            this.dbConnectionFactory = dbConnectionFactory;
            this.mapper = mapper;
            this.executionContext = executionContext;
        }

        public async Task<List<BillDto>> Handle(GetAllBills request, CancellationToken cancellationToken)
        {
            var connection = dbConnectionFactory.GetDbConnection();

            const string sql = "SELECT B.Id, B.Date, S.Id, S.Name " +
                               "FROM Bills B LEFT JOIN " +
                               "Stores S ON B.StoreId = S.Id";

            var bills = connection.Query<BillDto, StoreDto, BillDto>(
                sql,
                (bill, store) =>
                {
                    bill.Store = store;
                    return bill;
                })
                .ToList();

            return bills;
        }
    }
}
