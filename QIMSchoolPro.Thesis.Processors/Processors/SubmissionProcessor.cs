﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Qface.Application.Shared.Common.Interfaces;
using QIMSchoolPro.Thesis.Domain.Entities;
using QIMSchoolPro.Thesis.Domain.Enums;
using QIMSchoolPro.Thesis.Domain.ValueObjects;
using QIMSchoolPro.Thesis.Persistence.Interfaces;
using QIMSchoolPro.Thesis.Persistence.Migrations;
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
        private readonly SubmissionHistoryProcessor _submissionHistoryProcessor;
        private readonly IIdentityService _identityService;
        private readonly IStaffRepository _staffRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IAcademicConfigurationRepository _academicConfigurationRepository;

        public SubmissionProcessor(ISubmissionRepository submissionRepository, IDocumentRepository documentRepository,
            IVersionRepository versionRepository, IMapper mapper, SubmissionHistoryProcessor submissionHistoryProcessor,
             IStaffRepository staffRepository, IStudentRepository studentRepository, IIdentityService identityService,
             IAcademicConfigurationRepository academicConfigurationRepository)
        {
            _submissionRepository = submissionRepository;
            _documentRepository = documentRepository;
            _versionRepository = versionRepository;
            _mapper = mapper;
            _submissionHistoryProcessor = submissionHistoryProcessor;
            _identityService = identityService; 
            _staffRepository= staffRepository;
            _studentRepository= studentRepository;
            _academicConfigurationRepository = academicConfigurationRepository;

        }

        public async Task DeleteSubmission(long id)
        {
            var submission = await _submissionRepository.GetAsync((int)id);
            if (submission == null)
            {
                throw new Exception("Entry not Found");
            }

            await _submissionRepository.SoftDeleteAsync(submission);
        }

        public async Task Create( string title, string _abstract, IFormFile primaryFile, IFormFile thesisForm, IFormFile secondaryFile, CancellationToken cancellationToken)
        {
            try
            {
                
                var academicPeriod = await _academicConfigurationRepository.GetAcademicPeriodsAsync();
                var studentNumber = _identityService.GetUserName();

                var student = await _studentRepository.GetStudentByNumber(studentNumber);
                
                var submission = Submission.Create(studentNumber, _abstract, title, TransitionState.Created, DateTime.UtcNow, academicPeriod.AcademicPeriod, 1);
                await _submissionRepository.InsertAsync(submission, cancellationToken);

                await _submissionHistoryProcessor.SaveSubmissionHistory(submission.Id, student.PartyId, Activity.CreateSubmission, DateTime.UtcNow, cancellationToken);

                
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
                    var postSubmission = submission.Update(command.Abstract, command.Title, TransitionState.Department_Review, DateTime.UtcNow, submission.Trip);
                    await _submissionRepository.UpdateAsync(postSubmission);

                    var studentNumber = _identityService.GetUserName();
                    var student = await _studentRepository.GetStudentByNumber(studentNumber);

                               await _submissionHistoryProcessor.SaveSubmissionHistory(submission.Id, student.PartyId, Activity.DepartmentReview, DateTime.UtcNow, cancellationToken);


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
                var username = _identityService.GetUserName();
                //var email = "department@localhost.com";

                var staff = await _staffRepository.GetStaffByEmail(username);

                var submissions = await _submissionRepository.GetDepartmentSubmissions(staff.DepartmentId);

                var dd = _mapper.Map<List<SubmissionDto>>(submissions);
                return dd;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        public async Task SubmissionDecision(int submissionId, int decision)
        {
            try
            {
                var submission = await _submissionRepository.GetAsync(submissionId);
                var updateSubmission = submission.Decide((DecisionState)decision);

                await _submissionRepository.UpdateAsync(updateSubmission);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task Publish(int id)
        {
            try
            {
                var submission = await _submissionRepository.GetAsync(id);
                var updateSubmission = submission.PublishIt(true);

                await _submissionRepository.UpdateAsync(updateSubmission);
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


        public async Task<List<SubmissionDto>> GetDepartmentProcessedReviews()
        {
            try
            {
                var username = _identityService.GetUserName();
                //var email = "department@localhost.com";

                var staff = await _staffRepository.GetStaffByEmail(username);

                var submissions = await _submissionRepository.GetDepartmentProcessedReviews(staff.DepartmentId);

                var dd = _mapper.Map<List<SubmissionDto>>(submissions);
                return dd;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        public async Task<List<SubmissionDto>> GetSPSProcessedReviews()
        {
            try
            {
                var submissions = await _submissionRepository.GetSPSProcessedReviews();
                var data = _mapper.Map<List<SubmissionDto>>(submissions);

                return data;
          
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<List<SubmissionDto>> GetReportSubmissions()
        {
            try
            {
                var submissions = await _submissionRepository.GetReportSubmissions();
                var data = _mapper.Map<List<SubmissionDto>>(submissions);

                return data;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<List<SubmissionDto>> GetStudentReportSubmissions()
        {
            try
            {
                var username  = _identityService.GetUserName();
                var submissions = await _submissionRepository.GetStudentReportSubmissions(username);
                var data = _mapper.Map<List<SubmissionDto>>(submissions);

                return data;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<List<SubmissionDto>> GetDepartmentReportSubmissions()
        {
            try
            {
                var username = _identityService.GetUserName();
                var staff = await _staffRepository.GetStaffByEmail(username);

                var submissions = await _submissionRepository.GetDepartmentReportSubmissions(staff.DepartmentId);
                var data = _mapper.Map<List<SubmissionDto>>(submissions);

                return data;

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


        public async Task DepartmentApproval(int submissionId, int approvalId, CancellationToken cancellationToken)
        {
            try
            {
                var submission = await _submissionRepository.GetAsync(submissionId);

                var email = _identityService.GetUserName();
                var staff = await _staffRepository.GetStaffByEmail(email);


               

                if ((ReviewDecision)approvalId == ReviewDecision.Approve)
                {
                    var approve = submission.Transit(TransitionState.SPS_Review);
                    await _submissionRepository.UpdateAsync(approve);

                    await _submissionHistoryProcessor.SaveSubmissionHistory(submission.Id, staff.PartyId, Activity.SPSReview, DateTime.UtcNow, cancellationToken);

                }
                else
                {
                    var reject = submission.Transit(TransitionState.Created);
                    await _submissionRepository.UpdateAsync(reject);

                    await _submissionHistoryProcessor.SaveSubmissionHistory(submission.Id, staff.PartyId, Activity.DepartmentReject, DateTime.UtcNow, cancellationToken);

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

    //public class SPSProcessedViewModel
    //{
    //    public int SubmissionId { get; set; }
    //    public string StudentNumber { get; set; }
    //    public string StudentName { get; set; }
    //    public string Examiner { get; set; }
    //    public int TotalAssignment { get; set; }
    //    public int AcceptedAssignment { get; set; }
    //    public int RejectedAssignment { get; set; }
    //    public DateTime Deadline { get; set; }
    //}


}
