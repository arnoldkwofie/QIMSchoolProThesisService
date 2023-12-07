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
    public class ThesisAssignment : AuditableAutoEntity
    {
        public int Id { get; set; }
        public int SubmissionId { get; set; }
        //public Submission Submission { get; set; }
        public int StaffId { get; set; }
        public bool Accepted { get; set; }

        public ThesisAssignment() 
        {
        }

        public ThesisAssignment(int submissionId, int staffId)
        {
            SubmissionId = submissionId;
            StaffId = staffId;
        }

        public static ThesisAssignment Create(int submissionId, int staffId)
        {
            return new ThesisAssignment(
                submissionId, staffId
            );
        }
    }
}
