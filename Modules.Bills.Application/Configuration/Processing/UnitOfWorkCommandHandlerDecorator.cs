using BillAppDDD.Modules.Bills.Application.Contracts;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using URF.Core.Abstractions;

namespace BillAppDDD.Modules.Bills.Application.Configuration.Processing
{
    class UnitOfWorkCommandHandlerDecorator<T> : ICommandHandler<T> where T : ICommand
    {
        private readonly ICommandHandler<T> decorated;
        private readonly IUnitOfWork unitOfWork;

        public UnitOfWorkCommandHandlerDecorator(ICommandHandler<T> decorated, IUnitOfWork unitOfWork)
        {
            this.decorated = decorated;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(T request, CancellationToken cancellationToken)
        {
            await decorated.Handle(request, cancellationToken);

            await unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
