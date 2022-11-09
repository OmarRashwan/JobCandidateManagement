using EmployeeManagement.Business;
using EmployeeManagement.DataAccess.Services;
using EmployeeManagement.Services.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Test.Fixtures
{
    public class CandidateServiceFixture : IDisposable
    {
        public ICandidatesManagementRepository CandidateManagementTestDataRepository
        { get; }
        public CandidateService CandidateService 
            { get; }

        public CandidateServiceFixture()
        {
            CandidateManagementTestDataRepository =
                new CandidateTestDataRepository();
            CandidateService = new CandidateService(
                CandidateManagementTestDataRepository,
                new CandidateFactory());
        }

        public void Dispose()
        {
           // clean up the setup code, if required
        }
    }
}
