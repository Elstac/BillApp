using Autofac;
using BillAppDDD.BuildingBlocks.Infrastructure;
using BillAppDDD.Modules.Bills.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Modules.Bills.Infrastructure;
using URF.Core.Abstractions;
using URF.Core.EF;

namespace BillAppDDD.Modules.Bills.Application.Configuration
{
    class DataAccessModule : Module
    {
        private string connectionString;
        private ILoggerFactory loggerFactory;

        public DataAccessModule(
            string connectionString,
            ILoggerFactory loggerFactory
            )
        {
            this.connectionString = connectionString;
            this.loggerFactory = loggerFactory;
        }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<DbConnectionFactory>()
                .As<IDbConnectionFactory>()
                .WithParameter("connectionString", connectionString)
                .InstancePerLifetimeScope();

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
        }
    }
}
