using AutoMapper;
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

namespace QIMSchoolPro.Thesis.Processors.Processors
{
    [ProcessorBase]
    public class ThesisAssignmentProcessor
    {
        private readonly IThesisAssignmentRepository _thesisAssignmentRepository;
        private readonly IMapper _mapper;
        private readonly IIdentityService _identityService;

        public ThesisAssignmentProcessor(IThesisAssignmentRepository thesisAssignmentRepository, IMapper mapper, IIdentityService identityService)
        {
            _thesisAssignmentRepository = thesisAssignmentRepository;
            _mapper = mapper;
            _identityService = identityService;
        }

        public async Task Create(ThesisAssignmentCommand command, CancellationToken cancellationToken)
        {
            try
            {

                if (command != null)
                {

                    var thesisAssignment = ThesisAssignment.Create(command.SubmissionId, command.StaffId);
                    await _thesisAssignmentRepository.InsertAsync(thesisAssignment, cancellationToken);

                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<ThesisAssignmentDto>> GetByStaffId(int staffId)
        {

            var email = _identityService.GetEmail();

            //use email to get staffId
           var data = await _thesisAssignmentRepository.GetByStaffId(staffId);

            return _mapper.Map<List<ThesisAssignmentDto>>(data);
        }


    }

    public class ThesisAssignmentCommand
    {
        public int SubmissionId { get; set; }
        public int StaffId { get; set; }
        
    }

   
}
