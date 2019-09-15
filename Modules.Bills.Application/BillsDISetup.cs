using Autofac;
using BillAppDDD.Modules.Bills.Application.Bills.AddBill;
using BillAppDDD.Modules.Bills.Application.Bills.GetAllBills;
using BillAppDDD.Modules.Bills.Application.Stores.GetAllStores;
using BillAppDDD.Modules.Bills.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Modules.Bills.Infrastructure;
using URF.Core.Abstractions;
using URF.Core.EF;

namespace BillAppDDD.Modules.Bills.Application
{
    public static class BillsDISetup
    {
        public static void Initialize(string connectionString, ILoggerFactory loggerFactory)
        {
            var builder = new ContainerBuilder();

            builder.Register(
                c =>
                {
                    var opt = new DbContextOptionsBuilder<BillContext>();
                    opt.UseSqlServer(connectionString);
                    opt.UseLoggerFactory(loggerFactory);

                    return new BillContext(opt.Options);
                })
                .AsSelf()
                .As<DbContext>()
                .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(ExtendedRepository<>))
                .As(typeof(IExtendedRepository<>))
                .InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>();

            builder.RegisterType<Mediator>()
                .As<IMediator>();

            builder.Register<ServiceFactory>(context =>
            {
                var c = context.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });

            builder.RegisterType<AddBillCommandHandler>().AsImplementedInterfaces().InstancePerDependency();
            builder.RegisterType<GetAllBillsQueryHandler>().AsImplementedInterfaces().InstancePerDependency();
            builder.RegisterType<GetAllStoresQueryHandler>().AsImplementedInterfaces().InstancePerDependency();

            BillsCompositionRoot.SetContainer(builder.Build());
        }
    }
}
