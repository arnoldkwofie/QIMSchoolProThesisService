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
    public class StaffProcessor
    {
        private readonly IStaffRepository _staffRepository;
        private readonly IMapper _mapper;
        private readonly ISubmissionRepository _submissionRepository;


        public StaffProcessor(IStaffRepository staffRepository, IMapper mapper, ISubmissionRepository submissionRepository)
        {
            _staffRepository = staffRepository;
            _mapper = mapper;
            _submissionRepository = submissionRepository;
        }


        public async Task<List<StaffLookUpModel>> StaffLookUp(int Id)
        {
            try { 

                var submission = await _submissionRepository.Get(Id);
                int departmenId = submission.Student.Programme.Department.Id;

            var data = await _staffRepository.GetStaffInDepartment(departmenId);
                var result = new List<StaffLookUpModel>();
                foreach(var item in data)
                {
                    result.Add(new StaffLookUpModel
                    {
                        Id = item.Id,
                        Name=item.Party.Name.FirstName +' '+ item.Party.Name.LastName,
                    }
                        
                       );
                }

                return result;  
            }catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<StaffDto> GetStaffByEmail(string email)
        {
            var staff = await _staffRepository.GetStaffByEmail(email);
            //AddStaffDetailToObject(staff);
            return _mapper.Map<StaffDto>(staff);

        }

    }

    public class StaffLookUpModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }


}

