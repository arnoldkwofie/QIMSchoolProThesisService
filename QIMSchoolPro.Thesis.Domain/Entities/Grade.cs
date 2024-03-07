using Qface.Domain.Shared.Common;
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

    }
}
