using MediatR;

namespace BillAppDDD.Modules.Bills.Application.Contracts
{
    interface ICommandHandler<TCommand>: IRequestHandler<TCommand> where TCommand: ICommand
    {
    }
}
