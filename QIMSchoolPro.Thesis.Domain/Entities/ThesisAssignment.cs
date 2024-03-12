using Qface.Domain.Shared.Common;
using QIMSchoolPro.Thesis.Domain.Enums;
using QIMSchoolPro.Thesis.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QIMSchoolPro.Thesis.Domain.Entities
{
    public class ThesisAssignment : AuditableAutoEntity
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Submission))]
        public int SubmissionId { get; set; }
        public Submission Submission { get; set; }
        public int StaffId { get; set; }
        public Staff Staff { get; set; }
        public ReviewDecision Decision { get; set; }
        public ReviewerType ReviewerType { get; set; }
        public int Trip { get; set; }
        public DateTime Deadline { get; set; }
        public bool Assessment { get; set; }

        public ThesisAssignment() 
        {
        }

        public ThesisAssignment(int submissionId, int staffId, ReviewerType reviewerType, int trip, DateTime deadline, ReviewDecision decision)
        {
            SubmissionId = submissionId;
            StaffId = staffId;
            ReviewerType = reviewerType;
            Trip = trip;
            Deadline = deadline;
            Decision= decision;
        }

        public static ThesisAssignment Create(int submissionId, int staffId, ReviewerType reviewerType, int trip, DateTime deadline, ReviewDecision decision)
        {
            return new ThesisAssignment(
                submissionId, staffId, reviewerType, trip, deadline.ToUniversalTime(), decision
            ) ;
        }

        public ThesisAssignment Decide(ReviewDecision decision)
        {
            Decision = decision;
            return this;
        }

        public ThesisAssignment Assess()
        {
            Assessment = true;
            return this;
        }
    }
}
