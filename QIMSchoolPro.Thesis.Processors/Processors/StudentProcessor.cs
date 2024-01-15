




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
    public class StudentProcessor
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;


        public StudentProcessor(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }


        public async Task<StudentDto> Get(int Id)
        {
            try
            {
                var student = await _studentRepository.GetAsync(Id);
                var dd = _mapper.Map<StudentDto>(student);
                return dd;


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }




}
