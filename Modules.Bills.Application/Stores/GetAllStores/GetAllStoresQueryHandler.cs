using BillAppDDD.Modules.Bills.Application.Stores.Dto;
using BillAppDDD.Modules.Bills.Domain.Stores;
using BillAppDDD.Modules.Bills.Infrastructure;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BillAppDDD.Modules.Bills.Application.Stores.GetAllStores
{
    class GetAllStoresQueryHandler : IRequestHandler<GetAllStores, List<StoreDto>>
    {
        private IExtendedRepository<Store> storeRepository;

        public GetAllStoresQueryHandler(IExtendedRepository<Store> storeRepository)
        {
            this.storeRepository = storeRepository;
        }

        public async Task<List<StoreDto>> Handle(GetAllStores request, CancellationToken cancellationToken)
        {
            var storeCollection = storeRepository
                .Queryable()
                .Select(
                    s => new StoreDto
                    {
                        Name = s.Name
                    }
                )
                .ToList();

            return storeCollection;
        }
    }
}
