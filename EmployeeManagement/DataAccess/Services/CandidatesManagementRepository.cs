using EmployeeManagement.DataAccess.DbContexts;
using EmployeeManagement.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.DataAccess.Services
{
    public class CandidatesManagementRepository : ICandidatesManagementRepository
    {
        private readonly CandidateDbContext _context;

        public CandidatesManagementRepository(CandidateDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<CandidateDetails>> GetCandidatesAsync()
        {
            return await _context.CandidateDetails
                .ToListAsync(); 
        }

        public async Task<CandidateDetails?> GetCandidateAsync(Guid employeeId)
        {
            return await _context.CandidateDetails
                .FirstOrDefaultAsync(e => e.Id == employeeId);
        }

        public CandidateDetails? GetCandidate(Guid employeeId)
        {
            return _context.CandidateDetails
                .FirstOrDefault(e => e.Id == employeeId);
        }
        public void AddCandidate(CandidateDetails internalEmployee)
        {
            _context.CandidateDetails.Add(internalEmployee);
        }

        public void UpdateCandidate(CandidateDetails internalEmployee)
        {
            _context.CandidateDetails.Update(internalEmployee);
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
