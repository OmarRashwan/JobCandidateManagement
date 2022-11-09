using EmployeeManagement.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EmployeeManagement.Test
{
    public class CandidateTests
    {
        [Fact]
        public void EmployeeFullNamePropertyGetter_InputFirstNameAndLastName_FullNameIsConcatenation()
        {
            // Arrange
            var Candidate = new CandidateDetails("Kevin", "Dockx", "123456789", "omar@email.com", "20221201", "linkedin.com", "github.com", "Test");

            // Act
            Candidate.FirstName = "Lucia";
            Candidate.LastName = "SHELTON";

            // Assert
            Assert.Equal("Lucia Shelton", Candidate.FullName, ignoreCase:true);
        }

        [Fact]
        public void EmployeeFullNamePropertyGetter_InputFirstNameAndLastName_FullNameStartsWithFirstName()
        {
            // Arrange
            var employee = new CandidateDetails("Kevin", "Dockx", "123456789","omar@email.com","20221201","linkedin.com","github.com","Test");

            // Act
            employee.FirstName = "Lucia";
            employee.LastName = "Shelton";

            // Assert
            Assert.StartsWith(employee.FirstName, employee.FullName);
        }

        [Fact]
        public void EmployeeFullNamePropertyGetter_InputFirstNameAndLastName_FullNameEndsWithFirstName()
        {
            // Arrange
            var employee = new CandidateDetails("Kevin", "Dockx", "123456789", "omar@email.com", "20221201", "linkedin.com", "github.com", "Test");

            // Act
            employee.FirstName = "Lucia";
            employee.LastName = "Shelton";

            // Assert
            Assert.EndsWith(employee.LastName, employee.FullName);
        }

        [Fact]
        public void EmployeeFullNamePropertyGetter_InputFirstNameAndLastName_FullNameContainsPartOfConcatenation()
        {
            // Arrange
            var employee = new CandidateDetails("Kevin", "Dockx", "123456789", "omar@email.com", "20221201", "linkedin.com", "github.com", "Test");

            // Act
            employee.FirstName = "Lucia";
            employee.LastName = "Shelton";

            // Assert
            Assert.Contains("ia Sh", employee.FullName);
        }

        [Fact]
        public void EmployeeFullNamePropertyGetter_InputFirstNameAndLastName_FullNameSoundsLikeConcatenation()
        {
            // Arrange
            var employee = new CandidateDetails("Kevin", "Dockx", "123456789", "omar@email.com", "20221201", "linkedin.com", "github.com", "Test");

            // Act
            employee.FirstName = "Lucia";
            employee.LastName = "Shelton";

            // Assert
            Assert.Matches("Lu(c|s|z)ia Shel(t|d)on", employee.FullName);
        }
    }
}
