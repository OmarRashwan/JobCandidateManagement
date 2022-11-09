using AutoMapper;
using EmployeeManagement.Business;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [Route("api/candidates")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService  _candidateService;
        private readonly IMapper _mapper;

        public CandidateController(ICandidateService candidateService, 
            IMapper mapper)
        {
            _candidateService = candidateService;
            _mapper = mapper;
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<CandidateDto>>> GetCandidates()
        //{
        //    var candidate = await _candidateService.FetchCandidatesAsync();

        //    // with manual mapping
        //    //var internalEmployeeDtos =
        //    //    internalEmployees.Select(e => new InternalEmployeeDto()
        //    //    {
        //    //        Id = e.Id,
        //    //        FirstName = e.FirstName,
        //    //        LastName = e.LastName,
        //    //        Phone = e.Phone,
        //    //        LinkedinProfile = e.LinkedinProfile,
        //    //        GitHubProfile = e.GitHubProfile,
        //    //        FreeTextComment=e.FreeTextComment,
        //    //        Email =e.Email,
        //    //        TimeInterval=e.TimeInterval

        //    //   });

        //    // with AutoMapper
        //    var internalEmployeeDtos =
        //        _mapper.Map<IEnumerable<CandidateDto>>(candidate);

        //    return Ok(internalEmployeeDtos);
        //}

        //[HttpGet("{employeeId}", Name = "GetCandidate")]
        //public async Task<ActionResult<CandidateDto>> GetCandidate(
        //    Guid? employeeId)
        //{
        //    if (!employeeId.HasValue)
        //    {
        //        return NotFound();
        //    }

        //    var internalEmployee = await _candidateService.FetchCandidate(employeeId.Value);
        //    if (internalEmployee == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(_mapper.Map<CandidateDto>(internalEmployee));
        //}


        [HttpPost]
        public async Task<ActionResult<CandidateDto>> CreateAndUpdateCandidate(
            CandidateForCreationDto candidateForCreationDto)
        { 
         
            var candidateDetails =
                    await _candidateService.CreateCandidateAsync(candidateForCreationDto);
           
       if(candidateForCreationDto.Id !=null)
                candidateDetails.Id = candidateForCreationDto.Id.Value;
                await _candidateService.UpdateAndAddCandidateAsync(candidateDetails);
          

            return Ok();

            // return created employee after mapping to a DTO
            //return CreatedAtAction("GetCandidate",
            //    _mapper.Map<CandidateDto>(candidateDetails),
            //    new { employeeId = candidateDetails.Id } );
        }

    }
}
