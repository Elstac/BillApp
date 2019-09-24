using BillAppDDD.Modules.Bills.Application.Stores.Dto;
using BillAppDDD.Modules.Bills.Domain.Stores;
using BillAppDDD.Modules.Bills.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BillAppDDD.Modules.Bills.Application.Stores.GetAllStoresTotalSpendings
{
    class GetAllStoresTotalSpendingsQueryHandler : IRequestHandler<GetAllStoresTotalSpendings, List<StoreSpendingsDto>>
    {
        private IExtendedRepository<Store> storeRepo;

        public GetAllStoresTotalSpendingsQueryHandler(IExtendedRepository<Store> storeRepo)
        {
            this.storeRepo = storeRepo;
        }

        public async Task<List<StoreSpendingsDto>> Handle(GetAllStoresTotalSpendings request, CancellationToken cancellationToken)
        {
            var storeCollection = storeRepo
                .Queryable()
                .Include(s=>s.Bills)
                .ThenInclude(b=>b.Purchases)
                .ToList();

            var output = storeCollection
                .Select(
                s => new StoreSpendingsDto
                {
                    Name = s.Name,
                    TotalSpent = s.GetTotalSpendings()
                }
                )
                .ToList();

            return output;
        }
    }
}
