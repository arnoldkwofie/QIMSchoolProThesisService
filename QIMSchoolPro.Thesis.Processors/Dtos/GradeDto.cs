using Qface.Application.Shared.Dtos;
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
    public class GradeDto 
    {
        public int Id { get;  set; }
        public int ThesisAssignmentId { get;  set; }
        public ThesisAssignmentDto ThesisAssignment { get; set; }
        public int GradeParamId { get; set; }

        public GradeParamDto GradeParam { get; set; }
        public decimal Marks { get; set; }

    }
}
