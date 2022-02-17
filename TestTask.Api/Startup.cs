using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.IO;
using TestTask.Sql;
using AutoMapper;
using Autofac;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TestTask.Abstractions;
using TestTask.Core;
using Microsoft.AspNetCore.Authentication;

namespace TestTask.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // database registrations
            services.AddAllDbContext(Configuration);

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddRouting(c => c.LowercaseUrls = true);

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                var assemblyVersion = new Version("1.0");
                c.CustomSchemaIds(type => type.ToString());
                c.CustomOperationIds(d => (d.ActionDescriptor as ControllerActionDescriptor)?.ActionName);
                c.SwaggerDoc($"v{assemblyVersion}", new OpenApiInfo
                {
                    Version = $"v{assemblyVersion}",
                    Title = "Test task API",
                });
                c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    In = ParameterLocation.Header,
                    Description = "Basic Authorization header using the Bearer scheme."
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "basic"
                                }
                            },
                            new string[] {}
                    }
                });

                // add contract docs
                var xmlContractDocs = Directory.GetFiles(Path.Combine(AppContext.BaseDirectory), "*.Contract.xml");
                foreach (var fileName in xmlContractDocs) c.IncludeXmlComments(fileName);
            });

            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            services.AddScoped<IUserService, UserService>();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<Core.Module>();
            builder.RegisterModule<SqlModule>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseSwagger(c => { c.SerializeAsV2 = true; });

            app.UseSwaggerUI(c =>
            {
                var assemblyVersion = new Version("1.0");
                const string apiName = "PrivatePortal";
                c.SwaggerEndpoint($"/swagger/v{assemblyVersion}/swagger.json", $"{apiName} API V{assemblyVersion}");
                c.RoutePrefix = string.Empty;
                c.DocumentTitle = $"{apiName} Documentation";
                c.DocExpansion(DocExpansion.None);
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
