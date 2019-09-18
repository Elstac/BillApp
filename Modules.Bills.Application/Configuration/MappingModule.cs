using Autofac;
using AutoMapper;
using BillAppDDD.Modules.Bills.Application.Configuration.AutomapperProfiles;
using System;
using System.Linq;

namespace BillAppDDD.Modules.Bills.Application.Configuration
{
    class MappingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            var profiles =
                from t in typeof(BillProfile).Assembly.GetTypes()
                where typeof(Profile).IsAssignableFrom(t)
                select (Profile)Activator.CreateInstance(t);

            builder.Register(ctx => new MapperConfiguration(cfg =>
            {
                foreach (var profile in profiles)
                {
                    cfg.AddProfile(profile);
                }
            }));

            builder.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>();
        }
    }
}
