using EmployeeManagement.Business;
using EmployeeManagement.DataAccess.DbContexts;
using EmployeeManagement.DataAccess.Services;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement
{
    public static class ServiceRegistrationExtensions
    {
        public static IServiceCollection RegisterBusinessServices(
            this IServiceCollection services)
        {
            services.AddScoped<ICandidateService, CandidateService>();
            services.AddScoped<CandidateFactory>(); 
            return services;
        }

        public static IServiceCollection RegisterDataServices(
            this IServiceCollection services, IConfiguration configuration)
        {
            // add the DbContext
            services.AddDbContext<CandidateDbContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("CandidateManagementDB")));

            // register the repository
            services.AddScoped<ICandidatesManagementRepository, CandidatesManagementRepository>();
            return services;
        }
    }
}
