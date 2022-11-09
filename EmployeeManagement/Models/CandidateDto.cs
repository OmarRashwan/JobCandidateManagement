using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class CandidateDto
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string TimeInterval { get; set; }

        public string LinkedinProfile { get; set; }
        public string GitHubProfile { get; set; }

        public string FreeTextComment { get; set; }
    }
}
