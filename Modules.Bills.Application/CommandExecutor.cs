using Autofac;
using BillAppDDD.Modules.Bills.Application.Contracts;
using MediatR;
using System.Threading.Tasks;
using URF.Core.Abstractions;

namespace BillAppDDD.Modules.Bills.Application
{
    public interface ICommandExecutor
    {
        Task ExecuteCommandAsync(ICommand command);
    }

    public class CommandExecutor:ICommandExecutor
    {
        public async Task ExecuteCommandAsync(ICommand command)
        {
            using (var scope = BillsCompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();

                await mediator.Send(command);
            }
        }

    }
}
