using AutoMapper;
using Microsoft.AspNetCore.Http;
using QIMSchoolPro.Thesis.Domain.Entities;
using QIMSchoolPro.Thesis.Domain.Enums;
using QIMSchoolPro.Thesis.Domain.ValueObjects;
using QIMSchoolPro.Thesis.Persistence.Interfaces;
using QIMSchoolPro.Thesis.Processors.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QIMSchoolPro.Thesis.Processors.Processors
{
    [ProcessorBase]
    public class OralExaminationProcessor
    {
        private readonly IOralExaminationRepository _oralExaminationRepository;
        private readonly IMapper _mapper;

        public OralExaminationProcessor(IOralExaminationRepository oralExaminationRepository, IMapper mapper)
        {
           _oralExaminationRepository = oralExaminationRepository;
            _mapper = mapper;
        }


        public async Task Schedule(ScheduleCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (command.ExaminationDate < DateTime.UtcNow)
                    throw new Exception("Invalid Date");

                var examination = await _oralExaminationRepository.GetBySubmissionId(command.SubmissionNo);
                if (examination != null)
                    throw new Exception("Examination has already been scheduled");
               

                var entity = OralExamination.Create(command.SubmissionNo, command.ExaminationDate.ToUniversalTime());

                await _oralExaminationRepository.InsertAsync(entity, cancellationToken);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<OralExaminationDto>> GetAll()
        {
            try
            {
                var data = await _oralExaminationRepository.GetAllAsync();
                return _mapper.Map<List<OralExaminationDto>>(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }




    }



    public class ScheduleCommand
    {
        public int SubmissionNo { get; set; }
        public DateTime ExaminationDate { get; set; }

    }
}
