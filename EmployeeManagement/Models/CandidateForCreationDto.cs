using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class CandidateForCreationDto
    {
        public Guid? Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; } = string.Empty;

        public string Phone { get; set; }

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; }
        public string TimeInterval { get; set; }

        public string LinkedinProfile { get; set; }
        public string GitHubProfile { get; set; }

        [Required]
        [MaxLength(1000)]
        public string FreeTextComment { get; set; }
    }
}
