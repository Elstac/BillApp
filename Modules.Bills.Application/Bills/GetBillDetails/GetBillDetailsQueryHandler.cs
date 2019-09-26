using BillAppDDD.BuildingBlocks.Infrastructure;
using BillAppDDD.Modules.Bills.Application.Bills.Dto;
using BillAppDDD.Modules.Bills.Application.Stores.Dto;
using Dapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BillAppDDD.Modules.Bills.Application.Bills.GetBillDetails
{
    class GetBillDetailsQueryHandler : IRequestHandler<GetBillDetails, BillDetailsDto>
    {
        private IDbConnectionFactory dbConnectionFactory;

        public GetBillDetailsQueryHandler(IDbConnectionFactory dbConnectionFactory)
        {
            this.dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<BillDetailsDto> Handle(GetBillDetails request, CancellationToken cancellationToken)
        {
            var connection = dbConnectionFactory.GetDbConnection();

            const string sql = "SELECT * FROM BillDetails WHERE Id = @BillId";

            var rawBillData = connection.Query<BillDetailsV>(sql, new { request.BillId }).FirstOrDefault();

            return new BillDetailsDto
            {
                Date = rawBillData.Date,
                Id = rawBillData.Id,
                Store = new StoreDto
                {
                    Id = rawBillData.StoreId,
                    Name = rawBillData.StoreName
                },
                Purchases = JsonConvert.DeserializeObject<List<PurchaseDto>>(rawBillData.PurchasesJSON)
            };
        }
    }
}
