using AutoMapper;
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
        private IMapper mapper;

        public GetAllStoresQueryHandler(IExtendedRepository<Store> storeRepository, IMapper mapper)
        {
            this.storeRepository = storeRepository;
            this.mapper = mapper;
        }

        public async Task<List<StoreDto>> Handle(GetAllStores request, CancellationToken cancellationToken)
        {
            var storeCollection = storeRepository
                .Queryable()
                .ToList();

            return mapper.Map<List<StoreDto>>(storeCollection);
        }
    }
}
