using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QIMSchoolPro.Thesis.Processors.Dtos
{
    public class ExaminerReportDto
    {
        public int Id { get;  set; }
        public int ThesisAssignmentId { get;  set; }
        //public ThesisAssignmentDto ThesisAssignment { get; private set; }
        public string Path { get;  set; }
    }
}
