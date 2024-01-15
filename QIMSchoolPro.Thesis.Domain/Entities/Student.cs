using Qface.Domain.Shared.Common;
using QIMSchoolPro.Students.Domain.ValueObjects;
using QIMSchoolPro.Thesis.Domain.Enums;
using QIMSchoolPro.Thesis.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QIMSchoolPro.Thesis.Domain.Entities
{
    public class Student : AuditableAutoEntity
    {
        [Key]
        public string StudentNumber { get; set; }
        public string IndexNumber { get; set; }
        public YearGroup YearGroup { get; set; }
        public StudentStatus? StudentStatus { get; set; }
        public string StudentType { get; set; }
        public StudentSection StudentSection { get; set; }
        //public Guardian Guardian { get; set; }

        public int PartyId { get; set; }
        public Party Party { get; set; }
        


        //public StudentProgrammeCategory? StudentProgrammeCategory { get; set; }
        //public string UserId { get; set; }

        //public IReadOnlyList<StudentRegistration> StudentRegistrations => _studentRegistrations.AsReadOnly();

        public Programme Programme { get; private set; }
        //public int ProgrammeId { get; private set; }
        public int ProgrammeId { get; set; }
        //public Applicant Applicant { get; set; }
        //public long? ApplicantId { get; set; }


    }
}
