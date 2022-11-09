using EmployeeManagement.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.DataAccess.DbContexts
{
    public class CandidateDbContext : DbContext
    {
        public DbSet<CandidateDetails>  CandidateDetails { get; set; } = null!;

        public CandidateDbContext(DbContextOptions<CandidateDbContext> options)
         : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
      
            modelBuilder.Entity<CandidateDetails>()
                .HasData(
                    new CandidateDetails("Megan", "Jones", "3", "hh@em.com", "333", "linked", "github", "test")
                    {
                        Id = Guid.Parse("72f2f5fe-e50c-4966-8420-d50258aefdcb") 
                    },
                    new CandidateDetails("Jaimy", "Johnson", "3", "hh@em.com","333","linked","github","test")
                    {
                        Id = Guid.Parse("f484ad8f-78fd-46d1-9f87-bbb1e676e37f") 
                    });

             
        }
    }
}
