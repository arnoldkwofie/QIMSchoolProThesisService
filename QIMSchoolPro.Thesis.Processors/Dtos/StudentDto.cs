using Qface.Application.Shared.Dtos;
using Qface.Domain.Shared.Common;
using QIMSchoolPro.Students.Domain.ValueObjects;
using QIMSchoolPro.Thesis.Domain.Enums;
using QIMSchoolPro.Thesis.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QIMSchoolPro.Thesis.Domain.Entities
{
    public class StudentDto 
    {
        public string StudentNumber { get; set; }
        public string IndexNumber { get; set; }
        public YearGroup YearGroup { get; set; }
        public StudentStatus? StudentStatus { get; set; }
        public string StudentType { get; set; }
        public StudentSection StudentSection { get; set; }
        public ProgrammeDto Programme { get; private set; }
        public PartyDto Party { get; set; } 


    }
}
