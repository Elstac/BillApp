using Autofac;
using BillAppDDD.Modules.Bills.Application.Configuration.Processing;
using BillAppDDD.Modules.Bills.Application.Contracts;

namespace BillAppDDD.Modules.Bills.Application.Configuration
{
    class ProcessingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterGenericDecorator(
                typeof(UnitOfWorkCommandHandlerDecorator<>),
                typeof(ICommandHandler<>)
                );
        }
    }
}
