using Autofac;
using BillAppDDD.Modules.UserAccess.Application;
using BillAppDDD.Modules.UserAccess.Application.Contracts;

namespace Modules.Bills.Infrastructure
{
    public class UserAccessAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CommandExecutor>()
                .As<ICommandExecutor>();

            builder.RegisterType<UserAccessModule>()
                .As<IUserAccessModule>();
        }
    }
}
