using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace EmployeeManagement.DataAccess.Entities
{
    public class CandidateDetails : Candidate
    {
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


        public CandidateDetails(
       
            string firstName,
            string lastName
            , string phone, string email, string timeInterval, string linkedinProfile, string gitHubProfile, string freeTextComment)
            : base(firstName, lastName)
        {
            Phone = phone;
            Email = email;
            TimeInterval = timeInterval;
            LinkedinProfile = linkedinProfile;
            GitHubProfile = gitHubProfile;
            FreeTextComment = freeTextComment;
        }

    }
}
