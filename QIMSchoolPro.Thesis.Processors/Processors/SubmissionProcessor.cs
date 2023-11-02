using AutoMapper;
using Microsoft.AspNetCore.Http;
using QIMSchoolPro.Thesis.Domain.Entities;
using QIMSchoolPro.Thesis.Domain.Enums;
using QIMSchoolPro.Thesis.Domain.ValueObjects;
using QIMSchoolPro.Thesis.Persistence.Interfaces;
using QIMSchoolPro.Thesis.Processors.Constants;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Version = QIMSchoolPro.Thesis.Domain.Entities.Version;

namespace QIMSchoolPro.Thesis.Processors.Processors
{
    [ProcessorBase]
    public class SubmissionProcessor
    {
        private readonly ISubmissionRepository _submissionRepository;
        private readonly IDocumentRepository _documentRepository;
        private readonly IVersionRepository _versionRepository;
        private readonly IMapper _mapper;
        private readonly ISubmissionHistoryRepository _submissionHistoryRepository;

        public SubmissionProcessor(ISubmissionRepository submissionRepository, IDocumentRepository documentRepository,
            IVersionRepository versionRepository, IMapper mapper, ISubmissionHistoryRepository submissionHistoryRepository)
        {
            _submissionRepository = submissionRepository;
            _documentRepository = documentRepository;
            _versionRepository = versionRepository;
            _mapper = mapper;
            _submissionHistoryRepository=submissionHistoryRepository;
        }

        public async Task Create(string studentNumber, string title, string _abstract, IFormFile primaryFile, IFormFile secondaryFile, CancellationToken cancellationToken)
        {
            try
            {
                //generate system AcademicPeriod
                studentNumber = "50012458723";
                var academicPeriod = AcademicPeriod.Create("2022/2023", Semester.FirstSemester);
                var submission = Submission.Create(studentNumber, _abstract, title, TransitionState.Created, DateTime.UtcNow, academicPeriod);
                await _submissionRepository.InsertAsync(submission, cancellationToken);

                var submissionHistory = SubmissionHistory.Create(submission.Id, 1, Activity.CreateSubmission, DateTime.UtcNow);
                await _submissionHistoryRepository.InsertAsync(submissionHistory, cancellationToken);

                if (primaryFile != null)
                {
                    var document = Document.Create(submission.Id, DocumentType.Primary, "PrimaryFile");
                    await _documentRepository.InsertAsync(document, cancellationToken);

                    var version = Version.Create(document.Id, "v1", primaryFile.FileName, 1);
                    await _versionRepository.InsertAsync(version, cancellationToken);
                    
                }
                if (secondaryFile != null)
                {
                    var document = Document.Create(submission.Id, DocumentType.Secondary, "SecondaryFile");
                    await _documentRepository.InsertAsync(document, cancellationToken);

                    var version = Version.Create(document.Id, "v1", secondaryFile.FileName, 1);
                    await _versionRepository.InsertAsync(version, cancellationToken);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<List<SubmissionDto>> GetUserSubmissions()
        {
            try
            {
                var data = await _submissionRepository.GetUserSubmissions();
                var dd = _mapper.Map<List<SubmissionDto>>(data);
                return dd;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public async Task<SubmissionDto> Get(int id)
        {
            try
            {
                var data = await _submissionRepository.Get(id);
                var dd = _mapper.Map<SubmissionDto>(data);
                return dd;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


    }

    //public class SubmissionCommand
    //{
    //    public string StudentNumber { get; set; }
    //    public string Title { get; set; }
    //    public string Abstract { get; set; }
    //    public IFormFile PrimaryFile { get; set; }
    //    public IFormFile SecondaryFile { get; set; }
    //}

   
}
