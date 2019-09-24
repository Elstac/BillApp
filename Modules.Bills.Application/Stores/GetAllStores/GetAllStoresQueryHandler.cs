using AutoMapper;
using BillAppDDD.Modules.Bills.Application.Stores.Dto;
using BillAppDDD.Modules.Bills.Domain.Stores;
using BillAppDDD.Modules.Bills.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BillAppDDD.Modules.Bills.Application.Stores.GetAllStores
{
    class GetAllStoresQueryHandler : IRequestHandler<GetAllStores, List<StoreDetailsDto>>
    {
        private IExtendedRepository<Store> storeRepository;
        private IMapper mapper;

        public GetAllStoresQueryHandler(IExtendedRepository<Store> storeRepository, IMapper mapper)
        {
            this.storeRepository = storeRepository;
            this.mapper = mapper;
        }

        public async Task<List<StoreDetailsDto>> Handle(GetAllStores request, CancellationToken cancellationToken)
        {
            var storeCollection = storeRepository
                .Queryable()
                .Include(s=>s.Bills)
                .ToList();

            return mapper.Map<List<StoreDetailsDto>>(storeCollection);
        }
    }
}
