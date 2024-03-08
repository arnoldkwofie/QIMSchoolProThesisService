using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Qface.Application.Shared.Common.Interfaces;
using QIMSchoolPro.Thesis.Persistence.Interfaces;
using QIMSchoolPro.Thesis.Persistence.Repositories;
using QIMSchoolPRO.Thesis.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QIMSchoolPro.Thesis.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
        {
            services.RegisterDbContext(configuration)
                .RegisterRepositories();
            return services;
        }

        private static IServiceCollection RegisterDbContext(this IServiceCollection services,
        IConfiguration configuration)
        {
            var assemblyName = typeof(ThesisDbContext).Assembly.FullName;

            services.AddDbContext<ThesisDbContext>(options =>
               options.UseNpgsql(
                   configuration.GetConnectionString("DefaultConnection"),
                   b =>
                   {
                       b.MigrationsAssembly(assemblyName);
                   }));
            return services;
        }


        private static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<ISubmissionRepository, SubmissionRepository>();
            services.AddScoped<IDocumentRepository, DocumentRepository>();
            services.AddScoped<IVersionRepository, VersionRepository>();
            services.AddScoped<ISubmissionHistoryRepository, SubmissionHistoryRepository>();
            services.AddScoped<IThesisAssignmentRepository, ThesisAssignmentRepository>();
            services.AddScoped<IStaffRepository, StaffRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IProgrammeRepository, ProgrammeRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IGradeParamRepository, GradeParamRepository>();
            services.AddScoped<IGradeRepository, GradeRepository>();
            services.AddScoped<IAcademicConfigurationRepository, AcademicConfigurationRepository>();
            services.AddTransient<IIdentityService, IdentityService>();

            return services;
        }
    }
}
