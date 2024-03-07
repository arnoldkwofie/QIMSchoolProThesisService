using AutoMapper;
using Microsoft.AspNetCore.Http;
using QIMSchoolPro.Thesis.Domain.Entities;
using QIMSchoolPro.Thesis.Domain.Enums;
using QIMSchoolPro.Thesis.Domain.ValueObjects;
using QIMSchoolPro.Thesis.Persistence.Interfaces;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace QIMSchoolPro.Thesis.Processors.Processors
{
    [ProcessorBase]
    public class GradeParamProcessor
    {
        private readonly IGradeParamRepository _gradeParamRepository;
        private readonly IMapper _mapper;
       


        public GradeParamProcessor(IGradeParamRepository gradeParamRepository, IMapper mapper)
        {
            _gradeParamRepository = gradeParamRepository;
            _mapper = mapper;
            
        }

        public async Task<List<GradeParamDto>> GetAll()
        {
            var data = await _gradeParamRepository.GetAllAsync();
            var result = data.OrderBy(x => x.Order).ToList();
            return _mapper.Map<List<GradeParamDto>>(data);

        }

    }



}

