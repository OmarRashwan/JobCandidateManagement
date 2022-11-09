using EmployeeManagement.Business;
using EmployeeManagement.DataAccess.Services;
using EmployeeManagement.Services.Test;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagement.Test.Fixtures
{
    public class CandidateServiceWithAspNetCoreDIFixture : IDisposable
    {
        private readonly ServiceProvider _serviceProvider;

        public ICandidatesManagementRepository EmployeeManagementTestDataRepository
        {
            get
            {
#pragma warning disable CS8603 // Possible null reference return.
                return _serviceProvider.GetService<ICandidatesManagementRepository>();
#pragma warning restore CS8603 // Possible null reference return.
            }
        }

        public ICandidateService EmployeeService
        {
            get
            {
#pragma warning disable CS8603 // Possible null reference return.
                return _serviceProvider.GetService<ICandidateService>();
#pragma warning restore CS8603 // Possible null reference return.
            }
        }


        public CandidateServiceWithAspNetCoreDIFixture()
        {
            var services = new ServiceCollection();
            services.AddScoped<CandidateFactory>();
            services.AddScoped<ICandidatesManagementRepository,
                CandidateTestDataRepository>();
            services.AddScoped<ICandidateService, CandidateService>();

            // build provider
            _serviceProvider = services.BuildServiceProvider();
        }

        public void Dispose()
        {
            // clean up the setup code, if required
        }
    }
}
