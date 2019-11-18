using Autofac;
using Autofac.Extensions.DependencyInjection;
using BillAppDDD.Modules.Bills.Application.Configuration;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Modules.Bills.Infrastructure;
using System;
using System.Reflection;
using AutoMapper;

namespace BillAppDDD
{
    public class Startup
    {
        public Startup(IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            Configuration = configuration;
            this.loggerFactory = loggerFactory;
        }

        public IConfiguration Configuration { get; }
        private readonly ILoggerFactory loggerFactory;

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });

            AddSwagger(services);

            services.AddMediatR(Assembly.GetExecutingAssembly());

            return ConfigureDIContainer(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            UseCors(app);
            UseSwagger(app);

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });
        }

        private IServiceProvider ConfigureDIContainer(IServiceCollection services)
        {
            var builder = new ContainerBuilder();
            builder.Populate(services);

            builder.RegisterModule<BillsAutofacModule>();
            

            BillsDISetup.Initialize(
                "Server=.;Database=entityframework;Trusted_Connection=True;MultipleActiveResultSets=true;Database=BillApp.Bills",
                loggerFactory
                );

            return new AutofacServiceProvider(builder.Build());
        }

        private void UseCors(IApplicationBuilder app)
        {
            var corsConfiguration = Configuration.GetSection("Cors");

            app.UseCors(opt => opt
            .WithOrigins(corsConfiguration["origins"])
            .AllowAnyHeader()
            .AllowAnyMethod());
        }


        private static void UseSwagger(IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "BillApp API");
            });
        }

        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
        }
    }
}
