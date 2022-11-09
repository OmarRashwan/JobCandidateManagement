using AutoMapper;
using EmployeeManagement.DataAccess.Entities;

namespace EmployeeManagement.MapperProfiles
{
    public class CandidateProfile : Profile
    {
        public CandidateProfile()
        { 
            CreateMap<CandidateDetails, Models.CandidateDto>(); 
        }
    }
}
