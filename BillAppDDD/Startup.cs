using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using BillAppDDD.Modules.Bills.Application.Configuration;
using BillAppDDD.Modules.UserAccess.Application.Configuration;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Modules.Bills.Infrastructure;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
        private TokenValidationParameters validationParameters;

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
            ConfigureJwtBearer(services);

            return ConfigureDIContainer(services);
        }

        private void ConfigureJwtBearer(IServiceCollection services)
        {
            var jwtConfig = Configuration.GetSection("jwtTokenOptions");
            var key = Encoding.UTF8.GetBytes(jwtConfig["SECRET"]);
            
            validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwtConfig["ISSUER"],
                ValidateAudience = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ClockSkew = TimeSpan.Zero
            };

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.ClaimsIssuer = "KursyTutoriale";
                x.SaveToken = true;
                x.TokenValidationParameters = validationParameters;
                x.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            context.Response.Headers.Add("Token-Expired", "true");
                        }
                        return Task.CompletedTask;
                    }
                };
            });
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

            app.UseAuthentication();

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
            builder.RegisterModule<UserAccessAutofacModule>();

            var container = builder.Build();

            var httpContext = container.Resolve<IHttpContextAccessor>();
            var executionContext = new ExecutionContextAccessor(httpContext);

            BillsDISetup.Initialize(
                "Server=.;Database=entityframework;Trusted_Connection=True;MultipleActiveResultSets=true;Database=BillApp.Bills",
                loggerFactory,
                executionContext
                );

            UserAccessDISetup.Initialize(
                "Server=.;Database=entityframework;Trusted_Connection=True;MultipleActiveResultSets=true;Database=BillApp.UserAccess",
                loggerFactory,
                Configuration.GetSection("jwtTokenOptions"),
                validationParameters
                );

            return new AutofacServiceProvider(container);
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BillAppAPI", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                        },
                        new List<string>()
                    }
                });
            });
        }
    }
}
