using Autofac;
using BillAppDDD.Modules.Bills.Application;
using BillAppDDD.Modules.Bills.Application.Contracts;

namespace Modules.Bills.Infrastructure
{
    public class BillsAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CommandExecutor>()
                .As<ICommandExecutor>();

            builder.RegisterType<BillsModule>()
                .As<IBillsModule>();
        }
    }
}
