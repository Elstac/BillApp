using BillAppDDD.Modules.Bills.Application.Contracts;
using BillAppDDD.Modules.Bills.Domain.Bills;
using BillAppDDD.Modules.Bills.Infrastructure;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using URF.Core.Abstractions;

namespace BillAppDDD.Modules.Bills.Application.Bills.AddBill
{
    public class AddBillCommandHandler : ICommandHandler<AddBill>
    {
        private IExtendedRepository<Bill> repository;
        private IUnitOfWork unitOfWork;

        public AddBillCommandHandler(IExtendedRepository<Bill> repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(AddBill request, CancellationToken cancellationToken)
        {
            var input = request.BillInput;
            var toAdd = new Bill(input.Date);
            repository.InsertAggregate(toAdd);

            await unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
