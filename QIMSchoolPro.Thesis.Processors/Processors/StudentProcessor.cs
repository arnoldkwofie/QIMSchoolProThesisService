




using AutoMapper;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
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

        public async Task<StudentDto> GetStudentByNumber(string id)
        {
            //var student = await GetStudentInCache(id);
            //if (student == null)
            //{
                var studentFromDB =  await _studentRepository.GetStudentByNumber(id);
            if (studentFromDB == null)
                    return null;
            // studentFromDB.PhotoUrl = _photoService.GetStudentPhotoUrl(id);
            StudentDto student = _mapper.Map<StudentDto>(studentFromDB);

                //var hasBeCached = await _database.StringSetAsync(RedisKeys.GetStudentKey(id), JsonConvert.SerializeObject(student), TimeSpan.FromHours(4));
                //if (hasBeCached)
                //{
                //    _logger.LogInformation("student with Id {0} has been cache for 2 hrs", id);
                //}
       

            return student;

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
