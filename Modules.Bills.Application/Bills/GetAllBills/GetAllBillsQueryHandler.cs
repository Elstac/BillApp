using AutoMapper;
using BillAppDDD.Modules.Bills.Application.Bills.Dto;
using BillAppDDD.Modules.Bills.Domain.Bills;
using BillAppDDD.Modules.Bills.Infrastructure;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BillAppDDD.Modules.Bills.Application.Bills.GetAllBills
{
    internal class GetAllBillsQueryHandler : IRequestHandler<GetAllBills, List<BillDto>>
    {
        private IExtendedRepository<Bill> repository;
        private IMapper mapper;

        public GetAllBillsQueryHandler(IExtendedRepository<Bill> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<List<BillDto>> Handle(GetAllBills request, CancellationToken cancellationToken)
        {
            var billsCollection = repository
                .Queryable()
                .ToList();

            return mapper.Map<List<BillDto>>(billsCollection);
        }
    }
}
