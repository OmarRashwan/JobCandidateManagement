using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.Models;

namespace EmployeeManagement.Business
{
    /// <summary>
    /// Factory for creation employees
    /// </summary>
    public class CandidateFactory
    {
        /// <summary>
        /// Create an Candidate
        /// </summary>
        public virtual Candidate CreateCandidate(CandidateForCreationDto candidateForCreationDto)
        {
            if (string.IsNullOrEmpty(candidateForCreationDto.FirstName))
            {
                throw new ArgumentException($"'{nameof(candidateForCreationDto.FirstName)}' cannot be null or empty.",
                    nameof(candidateForCreationDto.FirstName));
            }

            if (string.IsNullOrEmpty(candidateForCreationDto.LastName))
            {
                throw new ArgumentException($"'{nameof(candidateForCreationDto.LastName)}' cannot be null or empty.",
                    nameof(candidateForCreationDto.LastName));
            }

            if (string.IsNullOrEmpty(candidateForCreationDto.Email))
            {
                throw new ArgumentException($"'{nameof(candidateForCreationDto.Email)}' cannot be null or empty.",
                    nameof(candidateForCreationDto.Email));
            }
            if (string.IsNullOrEmpty(candidateForCreationDto.FreeTextComment))
            {
                throw new ArgumentException($"'{nameof(candidateForCreationDto.FreeTextComment)}' cannot be null or empty.",
                    nameof(candidateForCreationDto.FreeTextComment));
            }

            // create a new employee with default values 
            return new CandidateDetails(candidateForCreationDto.FirstName, candidateForCreationDto.LastName, candidateForCreationDto.Phone, candidateForCreationDto.Email, candidateForCreationDto.TimeInterval, candidateForCreationDto.LinkedinProfile, candidateForCreationDto.GitHubProfile, candidateForCreationDto.FreeTextComment);

        }

        public bool ValdaiteCandidate(string Email)
        {
            String path = @"candidates.csv";
            bool IsValid = false;
            if (File.Exists(path))
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    String line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.Contains(","))
                        {
                            String[] split = line.Split(',');

                            if (split[1].Contains(Email))
                            {
                                IsValid = true;
                            }
                         
                        }

                    }
                }
            }
            return IsValid;
        }
    }
}
