using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.Models;

namespace EmployeeManagement.Business
{
    public interface ICandidateService
    {
        Task AddCandidateAsync(CandidateDetails candidateDetails);
        CandidateDetails CreateCandidate(CandidateForCreationDto candidateForCreationDto);
        Task<CandidateDetails> CreateCandidateAsync(CandidateForCreationDto candidateForCreationDto);
        Task<CandidateDetails?> FetchCandidate(Guid employeeId);
        Task<IEnumerable<CandidateDetails>> FetchCandidatesAsync();
        Task UpdateAndAddCandidateAsync(CandidateDetails candidateDetails);
        bool ValdaiteCandidate(string Email);
    }
}