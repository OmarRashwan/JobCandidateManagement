using EmployeeManagement.Business;
using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.Models;
using Xunit;

namespace EmployeeManagement.Test
{
    public class CandidateFactoryTests : IDisposable
    {
        private CandidateFactory _candidateFactory;

        public CandidateFactoryTests()
        {
            _candidateFactory = new CandidateFactory();
        }

        public void Dispose()
        {
           // clean up the setup code, if required
        }


        [Fact]
        [Trait("Category", "EmployeeFactory_CreateEmployee_Required")]
        public void CreateEmployee_ConstructInternalEmployee_LastNameRequired()
        {
            CandidateForCreationDto candidateForCreationDto = new CandidateForCreationDto()
            {
                FirstName = "Kevin",
                LastName = "Test",
                Email = "test@test.com",
                Phone = "01229987556",
                LinkedinProfile="linkedin.com",
                GitHubProfile = "github.com",
                TimeInterval= "20221201",
                FreeTextComment ="TEST"
            };
            
            var candidate = (CandidateDetails)_candidateFactory
                .CreateCandidate(candidateForCreationDto);

            Assert.True(candidate.LastName != null , "Last Name Is Required" );
        }

        [Fact]
        [Trait("Category", "EmployeeFactory_CreateEmployee_Required")]
        public void CreateEmployee_ConstructInternalEmployee_FirstNameMustBeNotNULL()
        {
            CandidateForCreationDto candidateForCreationDto = new CandidateForCreationDto()
            {
                FirstName = "Omar",
                LastName = "Docks",
                Email = "test@test.com",
                Phone = "01229987556",
                LinkedinProfile = "linkedin.com",
                GitHubProfile = "github.com",
                TimeInterval = "20221201",
                FreeTextComment = "TEST"
            };

            var candidate = (CandidateDetails)_candidateFactory
                .CreateCandidate(candidateForCreationDto);

            Assert.True(candidate.FirstName != null, "First Name Is Required");
        }

        [Fact]
        [Trait("Category", "EmployeeFactory_CreateEmployee_Required")]
        public void CreateEmployee_ConstructInternalEmployee_EmailMustBeNotNull()
        {
            CandidateForCreationDto candidateForCreationDto = new CandidateForCreationDto()
            {
                FirstName = "Kevin",
                LastName = "Docks",
                Email = "Omar@omar.com",
                Phone = "01229987556",
                LinkedinProfile = "linkedin.com",
                GitHubProfile = "github.com",
                TimeInterval = "20221201",
                FreeTextComment = "TEST"
            };

            var candidate = (CandidateDetails)_candidateFactory
                .CreateCandidate(candidateForCreationDto);

            Assert.True(candidate.Email != null, "Email Is Required");
        }

        [Fact]
        [Trait("Category", "EmployeeFactory_CreateEmployee_Required")]
        public void CreateEmployee_ConstructInternalEmployee_FreeTextComment()
        {
            CandidateForCreationDto candidateForCreationDto = new CandidateForCreationDto()
            {
                FirstName = "Kevin",
                LastName = "Docks",
                Email = "test@tt.com",
                Phone = "01229987556",
                LinkedinProfile = "linkedin.com",
                GitHubProfile = "github.com",
                TimeInterval = "20221201",
                FreeTextComment = "Test"
            };

            var candidate = (CandidateDetails)_candidateFactory
                .CreateCandidate(candidateForCreationDto);

            Assert.True(candidate.FreeTextComment != null, "Free Text Comment Is Required");
        }

        [Fact]
        [Trait("Category", "EmployeeFactory_CreateEmployee_ReturnType")]
        public void CreateEmployee_IsExternalIsTrue_ReturnTypeMustBeExternalEmployee()
        {
            // Arrange 
            CandidateForCreationDto candidateForCreationDto = new CandidateForCreationDto()
            {
                FirstName = "Kevin",
                LastName = "Docks",
                Email = "test@tt.com",
                Phone = "01229987556",
                LinkedinProfile = "linkedin.com",
                GitHubProfile = "github.com",
                TimeInterval = "20221201",
                FreeTextComment = "test"
            };
            // Act
            var candidate = _candidateFactory
                .CreateCandidate(candidateForCreationDto);

            // Assert
            Assert.IsType<CandidateDetails>(candidate);
        }

     
    }
}
