using BillAppDDD.Modules.Bills.Application.Dto;
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

        public GetAllBillsQueryHandler(IExtendedRepository<Bill> repository)
        {
            this.repository = repository;
        }

        public async Task<List<BillDto>> Handle(GetAllBills request, CancellationToken cancellationToken)
        {
            var billsCollection = repository.Queryable()
                .Select(
                b => new BillDto
                {
                    Date = b.Date
                })
                .ToList();

            return billsCollection;
        }
    }
}
