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

namespace QIMSchoolPro.Thesis.Processors.Processors
{
    [ProcessorBase]
    public class SubmissionHistoryProcessor
    {
        private readonly ISubmissionHistoryRepository _submissionHistoryProcessor;
        private readonly IMapper _mapper;

        public SubmissionHistoryProcessor(ISubmissionHistoryRepository submissionHistoryRepository, IMapper mapper)
        {
            _submissionHistoryProcessor = submissionHistoryRepository;
            _mapper = mapper;
        }


        public async Task<List<SubmissionHistoryDto>> GetSubmissionHistoryBySubmissionId(int id)
        {
            try
            {
                var data = await _submissionHistoryProcessor.GetSubmissionHistoryBySubmissionId(id);
                var dd = _mapper.Map<List<SubmissionHistoryDto>>(data);
                return dd;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }


   
}
