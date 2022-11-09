using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.DataAccess.Services;
using System.Threading.Tasks;

namespace EmployeeManagement.Services.Test
{
    public class CandidateTestDataRepository : ICandidatesManagementRepository
    {
        private List<CandidateDetails> _candidate;

        public CandidateTestDataRepository()
        {
            // mimic expensive creation process
            Thread.Sleep(3000);

            // initialize with dummy data 

            _candidate = new()
            {
                new CandidateDetails("Megan", "Jones", "2", "ee@jd.co","2323","link","git","comment")
                {
                    Id = Guid.Parse("72f2f5fe-e50c-4966-8420-d50258aefdcb")
                    
                },
                new CandidateDetails("Jaimy", "Johnson", "2", "ee@jd.co","2323","link","git","comment")
                {
                    Id = Guid.Parse("f484ad8f-78fd-46d1-9f87-bbb1e676e37f")
                }
            };

        }

        public void AddCandidate(CandidateDetails candidateDetails)
        {
            // empty on purpose
        }
        public CandidateDetails? GetCandidate(Guid candidateId)
        {
            return _candidate.FirstOrDefault(e => e.Id == candidateId);
        }

        public Task<CandidateDetails?> GetCandidateAsync(Guid candidateId)
        {
            return Task.FromResult(GetCandidate(candidateId));
        }

        public Task<IEnumerable<CandidateDetails>> GetCandidatesAsync()
        {
            return Task.FromResult(_candidate.AsEnumerable());
        }

        public void UpdateCandidate(CandidateDetails candidateDetails)
        {
            // empty on purpose
        }
        public Task SaveChangesAsync()
        {
            // nothing to do here
            return Task.CompletedTask;
        }
    }
}