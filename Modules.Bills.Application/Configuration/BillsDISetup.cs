using Autofac;
using BillAppDDD.BuildingBlocks.Application;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BillAppDDD.Modules.Bills.Application.Configuration
{
    public static class BillsDISetup
    {
        public static void Initialize(
            string connectionString,
            ILoggerFactory loggerFactory,
            IExecutionContextAccessor executionContext)
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule(new MediatorModule());
            builder.RegisterModule(new ProcessingModule());
            builder.RegisterModule(new DataAccessModule(connectionString,loggerFactory));
            builder.RegisterModule(new MappingModule());

            builder.RegisterInstance(executionContext);

            builder.Register<ServiceFactory>(context =>
            {
                var c = context.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });

            BillsCompositionRoot.SetContainer(builder.Build());
        }
    }
}
