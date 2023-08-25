using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using QIMSchoolPro.Thesis.Persistence;
using QIMSchoolPro.Thesis.Application;

namespace QIMSchoolProThesisService
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services,
                  IConfiguration configuration, IWebHostEnvironment hostEnvironment)
        {
            services.InstallDefaults()
                .AddHttpContextAccessor()
                .InstallSwagger(configuration)
                .AddCore(configuration)
                .AddInfrastructure(configuration);
           
        }
        private static IServiceCollection InstallDefaults(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            services.AddEndpointsApiExplorer()
                .InstallCors();
            return services;
        }

        private static IServiceCollection InstallCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(opts =>
                {
                    opts.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });
            return services;
        }

        private static IServiceCollection InstallSwagger(this IServiceCollection services,
           IConfiguration configuration)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "UMaT Thesis API",
                    Contact = new OpenApiContact
                    {
                        Email = "akwofie1@umat.edu.gh",
                        Name = "",
                        Url = new Uri("https://umat.edu.gh")
                    },
                    Description = "An API for thesis Management."
                });

                options.CustomOperationIds(description =>
                    description.TryGetMethodInfo(out var methodInfo)
                        ? methodInfo.Name : description.RelativePath);

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization using the bearer scheme",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {new OpenApiSecurityScheme{Reference = new OpenApiReference()
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }}, new List<string>()}
            });

                
            });
            return services;
        }


    }
}
