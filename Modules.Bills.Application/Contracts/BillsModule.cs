using Autofac;
using MediatR;
using System.Threading.Tasks;

namespace BillAppDDD.Modules.Bills.Application.Contracts
{
    public class BillsModule : IBillsModule
    {
        private ICommandExecutor commandExecutor;

        public BillsModule(ICommandExecutor commandExecutor)
        {
            this.commandExecutor = commandExecutor;
        }

        public async Task ExecuteCommandAsync(ICommand command)
        {
            await commandExecutor.ExecuteCommandAsync(command);
        }

        public async Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query)
        {
            using (var scope = BillsCompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();

                return await mediator.Send(query);
            }
        }
    }
}
