using QIMSchoolPro.Thesis.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QIMSchoolPro.Thesis.Processors.Dtos
{
    public class OralExaminationDto
    {
        public int Id { get;  set; }
        public int SubmissionId { get;  set; }
        public SubmissionDto Submission { get;  set; }
        public DateTime ExaminationDate { get;  set; }
    }
}
