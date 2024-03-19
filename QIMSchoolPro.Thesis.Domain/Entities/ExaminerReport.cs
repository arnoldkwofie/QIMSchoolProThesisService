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
    public class ExaminerReport : AuditableAutoEntity
    {
        public int Id { get; private set; }
        public int ThesisAssignmentId { get; private set; }
        public ThesisAssignment ThesisAssignment { get; private set; }
        public string Path { get; private set; }

        public ExaminerReport()
        {
            
        }
        public ExaminerReport(int thesisAssignmentId, string path)
        {
            ThesisAssignmentId = thesisAssignmentId;
            Path = path;
        }

        public static ExaminerReport Create(int thesisAssignmentId, string path)
        {
            return new ExaminerReport(
                thesisAssignmentId, path
            );
        }
    }
}
