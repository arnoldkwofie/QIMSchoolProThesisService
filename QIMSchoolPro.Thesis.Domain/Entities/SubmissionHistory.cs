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
    public class SubmissionHistory : AuditableAutoEntity
    {
        public int Id { get; set; }
        public int SubmissionId { get; set; }
        public int PartyId { get; set; }
        public string Activity { get; set; }
        public DateTime ActivityDate { get; set; }
        

        public SubmissionHistory() 
        {
        }

        public SubmissionHistory(int submissionId, int partyId, string activity, DateTime activityDate)
        {
           SubmissionId = submissionId;
            PartyId = partyId;
            Activity = activity;
            ActivityDate = activityDate;
        }

        public static SubmissionHistory Create(int submissionId, int partyId, string activity, DateTime activityDate)
        {
            return new SubmissionHistory(
                submissionId, partyId, activity, activityDate
            );
        }
    }
}
