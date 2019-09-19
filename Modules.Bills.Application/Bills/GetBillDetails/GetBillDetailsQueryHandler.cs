using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BillAppDDD.Modules.Bills.Application.Bills.Dto;
using BillAppDDD.Modules.Bills.Domain.Bills;
using BillAppDDD.Modules.Bills.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BillAppDDD.Modules.Bills.Application.Bills.GetBillDetails
{
    class GetBillDetailsQueryHandler : IRequestHandler<GetBillDetails, BillDetailsDto>
    {
        private IExtendedRepository<Bill> billRepo;
        private IMapper mapper;

        public GetBillDetailsQueryHandler(IExtendedRepository<Bill> billRepo, IMapper mapper)
        {
            this.billRepo = billRepo;
            this.mapper = mapper;
        }

        public async Task<BillDetailsDto> Handle(GetBillDetails request, CancellationToken cancellationToken)
        {
            var bill = billRepo
                .Queryable()
                .Include(b=>b.Purchases)
                .ThenInclude(p=>p.Product)
                .Include(b=>b.Store)
                .FirstOrDefault(b => b.Id == request.BillId);

            return mapper.Map<BillDetailsDto>(bill);
        }
    }
}
