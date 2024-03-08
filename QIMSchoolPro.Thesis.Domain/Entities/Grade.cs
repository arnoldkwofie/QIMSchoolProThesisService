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
    public class Grade : AuditableAutoEntity
    {
        public int Id { get; private set; }
        public int ThesisAssignmentId { get; private set; }
        public ThesisAssignment ThesisAssignment { get; set; }
        public int GradeParamId { get; set; }

        public GradeParam GradeParam { get; set; }
        public decimal Marks { get; set; }
        public string Comment { get; set; }

        public Grade()
        {
        }

        public Grade(int thesisAssignmentId, int gradeParamId, decimal marks, string comment)
        {
            ThesisAssignmentId = thesisAssignmentId;
            GradeParamId = gradeParamId;
            Marks = marks;
            Comment = comment;
           
        }

        public static Grade Create(int thesisAssignmentId, int gradeParamId, decimal marks, string comment)
        {
            return new Grade(
                thesisAssignmentId, gradeParamId, marks, comment
            );
        }
    }
}
