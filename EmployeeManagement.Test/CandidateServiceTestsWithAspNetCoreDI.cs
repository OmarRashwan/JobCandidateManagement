using EmployeeManagement.Models;
using EmployeeManagement.Test.Fixtures;
using Xunit;

namespace EmployeeManagement.Test
{
    public class CandidateServiceTestsWithAspNetCoreDI
        : IClassFixture<CandidateServiceWithAspNetCoreDIFixture>
    {
        private readonly CandidateServiceWithAspNetCoreDIFixture
            _candidateServiceFixture;

        public CandidateServiceTestsWithAspNetCoreDI(
            CandidateServiceWithAspNetCoreDIFixture candidateServiceWithAspNetCoreDIFixture)
        {
            _candidateServiceFixture = candidateServiceWithAspNetCoreDIFixture;
        }

        [Fact]
        public void CreateInternalEmployee_InternalEmployeeCreated()
        {
            // Arrange

            var candidate = _candidateServiceFixture
                .EmployeeManagementTestDataRepository
                .GetCandidate(Guid.Parse("72f2f5fe-e50c-4966-8420-d50258aefdcb"));

            // Act
            CandidateForCreationDto candidateForCreationDto = new CandidateForCreationDto()
            {
                FirstName = "Megan",
                LastName = "Jones",
                Email = "test@test.com",
                Phone = "01229987556",
                LinkedinProfile = "linkedin.com",
                GitHubProfile = "github.com",
                TimeInterval = "20221201",
                FreeTextComment = "TEST"
            };
            var candidateDetails = _candidateServiceFixture
                .EmployeeService.CreateCandidate(candidateForCreationDto);

            // Assert
            Assert.Contains(candidate.FirstName, candidateDetails.FirstName);
        }
    }
}
