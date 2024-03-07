﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using QIMSchoolPro.Thesis.Domain.Entities;
using QIMSchoolPro.Thesis.Domain.Enums;
using QIMSchoolPro.Thesis.Domain.ValueObjects;
using QIMSchoolPro.Thesis.Persistence.Interfaces;
using QIMSchoolPro.Thesis.Persistence.Repositories;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Version = QIMSchoolPro.Thesis.Domain.Entities.Version;

using Qface.Application.Shared.Common.Interfaces;
using System.Collections;
using QIMSchoolPro.Thesis.Processors.Constants;

namespace QIMSchoolPro.Thesis.Processors.Processors
{
    [ProcessorBase]
    public class ThesisAssignmentProcessor
    {
        private readonly IThesisAssignmentRepository _thesisAssignmentRepository;
        private readonly IMapper _mapper;
        private readonly ISubmissionRepository _submissionRepository;
        private readonly IIdentityService _identityService;
        private readonly SubmissionHistoryProcessor _submissionHistoryProcessor;
        private readonly IStaffRepository _staffRepository;
        public ThesisAssignmentProcessor(IThesisAssignmentRepository thesisAssignmentRepository, IMapper mapper, ISubmissionRepository submissionRepository,
            IIdentityService identityService, SubmissionHistoryProcessor submissionHistoryProcessor, IStaffRepository staffRepository)
        {
            _thesisAssignmentRepository = thesisAssignmentRepository;
            _mapper = mapper;
            _submissionRepository = submissionRepository;
            _submissionHistoryProcessor = submissionHistoryProcessor;
            _identityService = identityService;
            _staffRepository = staffRepository;

        }

        public async Task Create(ThesisAssignmentCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var email = _identityService.GetEmail();
                var staff = await _staffRepository.GetStaffByEmail(email);

                

                if (command != null)
                {
                    var submission = await _submissionRepository.GetAsync(command.SubmissionId);

                    var thesisAssignment = ThesisAssignment.Create(command.SubmissionId, command.StaffId, (ReviewerType)command.ReviewerType, submission.Trip, command.Deadline, ReviewDecision.Neutral);
                    await _thesisAssignmentRepository.InsertAsync(thesisAssignment, cancellationToken);

                    var review = submission.Transit(TransitionState.Examiner_Review);
                    await _submissionRepository.UpdateAsync(review);

                    await _submissionHistoryProcessor.SaveSubmissionHistory(submission.Id, staff.PartyId, Activity.ExaminerReview, DateTime.UtcNow, cancellationToken);

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<ThesisAssignmentDto>> GetByStaffId()
        {

            var email = _identityService.GetEmail();
             var staff = await _staffRepository.GetStaffByEmail(email);
            

           var data = await _thesisAssignmentRepository.GetByStaffId(staff.Id);
            var result = data.Where(a => a.Decision == ReviewDecision.Neutral);
            return _mapper.Map<List<ThesisAssignmentDto>>(result);
        }


        public async Task<List<ThesisAssignmentDto>> GetApprovedByStaffId()
        {
            try
            {
                var email = _identityService.GetEmail();
                var staff = await _staffRepository.GetStaffByEmail(email);


                var data = await _thesisAssignmentRepository.GetByStaffId(staff.Id);
                var result = data.Where(a => a.Decision == ReviewDecision.Approve);
                return _mapper.Map<List<ThesisAssignmentDto>>(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            
        }

        public async Task Decide(DecisionCommand command)
        {
            var thesisAssignment = await _thesisAssignmentRepository.GetAsync(command.Id);
            var data = thesisAssignment.Decide((ReviewDecision)command.Decision);
            await _thesisAssignmentRepository.UpdateAsync(data);

        }


    }

    public class ThesisAssignmentCommand
    {
        public int SubmissionId { get; set; }
        public int StaffId { get; set; }
        public int ReviewerType { get; set; }  
        public DateTime Deadline { get; set; }
        
    }

    public class DecisionCommand
    {
        public int Id { get; set; }
        public int Decision { get; set; }
    }

   
}
