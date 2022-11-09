using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EmployeeManagement.Test.Fixtures
{
    [CollectionDefinition("EmployeeServiceCollection")]
    public class CandidateServiceCollectionFixture 
        : ICollectionFixture<CandidateServiceFixture>
    {
    }
}
