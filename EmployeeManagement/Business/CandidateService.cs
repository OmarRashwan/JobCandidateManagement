using CsvHelper;
using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.DataAccess.Services;
using EmployeeManagement.Models;
using System.Globalization;
using System.Text;

namespace EmployeeManagement.Business
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidatesManagementRepository _repository;
        private readonly CandidateFactory _employeeFactory;


        public CandidateService(ICandidatesManagementRepository repository,
            CandidateFactory employeeFactory)
        {
            _repository = repository;
            _employeeFactory = employeeFactory;
        }

        public async Task<IEnumerable<CandidateDetails>> FetchCandidatesAsync()
        {
            var candidates = await _repository.GetCandidatesAsync();

            return candidates;
        }

        public async Task<CandidateDetails?> FetchCandidate(Guid employeeId)
        {
            var candidate = _repository.GetCandidate(employeeId);

            return candidate;
        }

        public CandidateDetails CreateCandidate(CandidateForCreationDto candidateForCreationDto)
        {
            // use the factory to create the object 
            var candidate = (CandidateDetails)_employeeFactory
                .CreateCandidate(candidateForCreationDto);

            return candidate;
        }

        public bool ValdaiteCandidate(string Email)
        {
            // use the factory to create the object 
            var candidate = _employeeFactory
                .ValdaiteCandidate(Email);

            return candidate;
        }
        public async Task<CandidateDetails> CreateCandidateAsync(
          CandidateForCreationDto candidateForCreationDto)
        {
            // use the factory to create the object 
            var candidate = (CandidateDetails)_employeeFactory.CreateCandidate(candidateForCreationDto);

            return candidate;
        }

        public async Task AddCandidateAsync(CandidateDetails candidateDetails)
        {
            String path = @"candidates.csv";
            candidateDetails.Id = Guid.NewGuid();
            List<CandidateDetails> candidate = new List<CandidateDetails>();
            candidate.Add(candidateDetails);
            using (StreamWriter sw = new StreamWriter(path, false, new UTF8Encoding(true)))
            using (CsvWriter cw = new CsvWriter(sw, CultureInfo.InvariantCulture))
            {
                cw.WriteHeader<CandidateDetails>();
                cw.NextRecord();
               
                    cw.WriteRecord<CandidateDetails>(candidate.FirstOrDefault());
                    cw.NextRecord();
                    cw.Flush();
                
                //_repository.AddCandidate(candidateDetails);
                //await _repository.SaveChangesAsync();
            }
        }

        public async Task UpdateAndAddCandidateAsync(CandidateDetails candidateDetails)
        {
            String path = @"candidates.csv";
            List<CandidateDetails> candidate = new List<CandidateDetails>();
            candidate.Add(candidateDetails);
            List<String> lines = new List<String>();
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

                            if (_employeeFactory.ValdaiteCandidate(candidateDetails.Email))
                            {
                                var res = candidate.FirstOrDefault();
                                if (res != null)
                                {
                                    split[0] = res.Phone;
                                    split[1] = res.Email;
                                    split[2] = res.TimeInterval;
                                    split[3] = res.LinkedinProfile;
                                    split[4] = res.GitHubProfile;
                                    split[5] = res.FreeTextComment;
                                    split[6] = res.Id.ToString();
                                    split[7] = res.FirstName;
                                    split[8] = res.LastName;
                                    line = String.Join(",", split);
                                }
                            }
                     
                        }

                        lines.Add(line);
                    }
                    if(candidateDetails != null)
                    {
                        line = AddCandidate(candidateDetails, candidate, lines, line);
                    }
                }

                using (StreamWriter writer = new StreamWriter(path, false))
                {
                    foreach (String line in lines)
                        writer.WriteLine(line);
                }
            }
             else
            {
                using (StreamWriter sw = new StreamWriter(path, false, new UTF8Encoding(true)))
                using (CsvWriter cw = new CsvWriter(sw, CultureInfo.InvariantCulture))
                {
                    if (candidate.FirstOrDefault() !=null)
                    candidate.FirstOrDefault().Id = Guid.NewGuid();
                    cw.WriteHeader<CandidateDetails>();
                    cw.NextRecord();

                    cw.WriteRecord<CandidateDetails>(candidate.FirstOrDefault());
                    cw.NextRecord();
                    cw.Flush();

                    //_repository.AddCandidate(candidateDetails);
                    //await _repository.SaveChangesAsync();
                }
            }

           // _repository.UpdateCandidate(candidateDetails);
            //await _repository.SaveChangesAsync();
        }

        private static string AddCandidate(CandidateDetails candidateDetails, List<CandidateDetails> candidate, List<string> lines, string line)
        {
            candidateDetails.Id = Guid.NewGuid();
            String[] newLine = new string[9];
            var result = candidate.FirstOrDefault();
            if (result != null)
            {
                newLine[0] = result.Phone;
                newLine[1] = result.Email;
                newLine[2] = result.TimeInterval;
                newLine[3] = result.LinkedinProfile;
                newLine[4] = result.GitHubProfile;
                newLine[5] = result.FreeTextComment;
                newLine[6] = result.Id.ToString();
                newLine[7] = result.FirstName;
                newLine[8] = result.LastName;
                line = String.Join(",", newLine);
                lines.Add(line);
            }

            return line;
        }
    }
}
