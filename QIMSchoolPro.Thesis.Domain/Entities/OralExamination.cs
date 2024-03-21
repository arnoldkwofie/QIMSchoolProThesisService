using Qface.Domain.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QIMSchoolPro.Thesis.Domain.Entities
{
    public class OralExamination : AuditableAutoEntity
    {
        public int Id { get; private set; }
        public int SubmissionId { get; private set; }
        public Submission Submission { get; private set; }
        public DateTime ExaminationDate  { get; private set; }

        public OralExamination()
        {

        }

        public OralExamination(int submissionId, DateTime examinationDate)
        {
            SubmissionId = submissionId;    
            ExaminationDate = examinationDate;
        }

        public static OralExamination Create(int submissionId, DateTime examinationDate)
        { 
            return new OralExamination(submissionId, examinationDate);
        
        }

    }
}
