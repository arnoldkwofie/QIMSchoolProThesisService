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
    public class Submission : AuditableAutoEntity
    {
        public int Id { get; set; }
        public string StudentNumber { get; set; }
        public TransitionState TransitionState { get; set; }
        public DateTime SubmissionDate { get; set; }
        public AcademicPeriod AcademicPeriod { get; set; }
    }
}
