using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using BillAppDDD.Modules.Bills.Application.Contracts;
using MediatR;

namespace BillAppDDD.Modules.Bills.Application.Configuration
{
    class MediatorModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<Mediator>()
                .As<IMediator>();

            builder.RegisterAssemblyTypes(ThisAssembly)
                .AsClosedTypesOf(typeof(ICommandHandler<>))
                .AsImplementedInterfaces()
                .InstancePerDependency();

            builder.RegisterAssemblyTypes(ThisAssembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>))
                .AsImplementedInterfaces()
                .InstancePerDependency();
        }
    }
}
