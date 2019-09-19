using BillAppDDD.Modules.Bills.Application.Contracts;
using BillAppDDD.Modules.Bills.Domain.Bills;
using BillAppDDD.Modules.Bills.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BillAppDDD.Modules.Bills.Application.Bills.RemoveBill
{
    class RemoveBillCommandHandler : ICommandHandler<RemoveBill>
    {
        private IExtendedRepository<Bill> billRepo;

        public RemoveBillCommandHandler(IExtendedRepository<Bill> billRepo)
        {
            this.billRepo = billRepo;
        }

        public async Task<Unit> Handle(RemoveBill request, CancellationToken cancellationToken)
        {
            var bill = billRepo.Queryable().FirstOrDefault(b => b.Id == request.BillId);

            billRepo.Delete(bill);

            return Unit.Value;
        }
    }
}
