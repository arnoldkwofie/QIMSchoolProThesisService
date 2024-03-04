using AutoMapper;
using Microsoft.AspNetCore.Http;
using Qface.Application.Shared.Common.Interfaces;
using QIMSchoolPro.Thesis.Domain.Entities;
using QIMSchoolPro.Thesis.Domain.Enums;
using QIMSchoolPro.Thesis.Domain.ValueObjects;
using QIMSchoolPro.Thesis.Persistence.Interfaces;
using QIMSchoolPro.Thesis.Processors.Constants;
using QIMSchoolPro.Thesis.Processors.Services;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
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
        private readonly IIdentityService _identityService;
        private readonly IStaffRepository _staffRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IAcademicConfigurationRepository _academicConfigurationRepository;

        public SubmissionProcessor(ISubmissionRepository submissionRepository, IDocumentRepository documentRepository,
            IVersionRepository versionRepository, IMapper mapper, ISubmissionHistoryRepository submissionHistoryRepository,
             IStaffRepository staffRepository, IStudentRepository studentRepository, IIdentityService identityService,
             IAcademicConfigurationRepository academicConfigurationRepository)
        {
            _submissionRepository = submissionRepository;
            _documentRepository = documentRepository;
            _versionRepository = versionRepository;
            _mapper = mapper;
            _submissionHistoryRepository = submissionHistoryRepository;
            _identityService = identityService; 
            _staffRepository= staffRepository;
            _studentRepository= studentRepository;
            _academicConfigurationRepository = academicConfigurationRepository;

        }

        public async Task Create( string title, string _abstract, IFormFile primaryFile, IFormFile thesisForm, IFormFile secondaryFile, CancellationToken cancellationToken)
        {
            try
            {
                
                var academicPeriod = await _academicConfigurationRepository.GetAcademicPeriodsAsync();
                var studentNumber = _identityService.GetUserName();
                
                var submission = Submission.Create(studentNumber, _abstract, title, TransitionState.Created, DateTime.UtcNow, academicPeriod.AcademicPeriod);
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
                if (thesisForm != null)
                {
                    var document = Document.Create(submission.Id, DocumentType.Primary, "ThesisForm");
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

        public async Task PostSubmission(SubmissionCommand command, CancellationToken cancellationToken)
        {
			try { 

                var submission= await _submissionRepository.GetAsync(command.Id);
                if (submission != null)
                {
					//var academicPeriod = AcademicPeriod.Create("2022/2023", Semester.FirstSemester);
                    var postSubmission = submission.Update(command.Abstract, command.Title, TransitionState.Department_Review, DateTime.UtcNow);
                    await _submissionRepository.UpdateAsync(postSubmission);
				}
            
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        
        }


        public async Task<List<SubmissionDto>> GetUserSubmissions()
        {
            try
            {
                var userame = _identityService.GetUserName();
               
                    var data = await _submissionRepository.GetUserSubmissions(userame);
                    var dd = _mapper.Map<List<SubmissionDto>>(data);
                    return dd;
              
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<List<SubmissionDto>> GetDepartmentSubmissions()
        {
            try
            {
                //var email = _identityService.GetEmail();
                var email = "department@localhost.com";

                var staff = await _staffRepository.GetStaffByEmail(email);

                var submissions = await _submissionRepository.GetDepartmentSubmissions(staff.DepartmentId);

                var dd = _mapper.Map<List<SubmissionDto>>(submissions);
                return dd;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<List<SubmissionDto>> GetSPSSubmissions()
        {
            try
            {
                
                var submissions = await _submissionRepository.GetSPSSubmissions();

                var dd = _mapper.Map<List<SubmissionDto>>(submissions);
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


        public async Task DepartmentApproval(int submissionId, int approvalId)
        {
            try
            {
                var submission = await _submissionRepository.GetAsync(submissionId);



                if ((ReviewDecision)approvalId == ReviewDecision.Approve)
                {
                    var approve = submission.Transit(TransitionState.SPS_Review);
                    await _submissionRepository.UpdateAsync(approve);

                    //TestMessage.Send("Your thesis has been approved by department", "233247761922");
                }
                else
                {
                    var reject = submission.Transit(TransitionState.Created);
                    await _submissionRepository.UpdateAsync(reject);
                    //get notification

                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


    }

    public class SubmissionCommand
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }

    }


}
