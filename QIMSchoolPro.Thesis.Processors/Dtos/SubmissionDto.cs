using Qface.Application.Shared.Dtos;
using Qface.Domain.Shared.Common;
using QIMSchoolPro.Thesis.Domain.Enums;
using QIMSchoolPro.Thesis.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QIMSchoolPro.Thesis.Domain.Entities
{
    public class SubmissionDto 
    {
        public int Id { get; set; }
        public string StudentNumber { get; set; }
        public StudentDto Student { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public TransitionState TransitionState { get; set; }
        public int Trip { get; set; }
        public DateTime SubmissionDate { get; set; }
        public AcademicPeriod AcademicPeriod { get; set; }
        //public AuditDto Audit { get; set; }
        public List<DocumentDto> Documents { get; set; }

        public List<SubmissionHistoryDto> SubmissionHistories { get; set; }
        public List<ThesisAssignmentDtoAnnex> ThesisAssignments { get; set; }

    }
}
