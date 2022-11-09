using EmployeeManagement.DataAccess.Entities;

namespace EmployeeManagement.DataAccess.Services
{
    public interface ICandidatesManagementRepository
    {
        void AddCandidate(CandidateDetails internalEmployee);
        CandidateDetails? GetCandidate(Guid employeeId);
        Task<CandidateDetails?> GetCandidateAsync(Guid employeeId);
        Task<IEnumerable<CandidateDetails>> GetCandidatesAsync();
        Task SaveChangesAsync();
        void UpdateCandidate(CandidateDetails internalEmployee);
    }
}