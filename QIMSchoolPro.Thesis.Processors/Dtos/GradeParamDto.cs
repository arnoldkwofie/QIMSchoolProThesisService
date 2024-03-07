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
    public class GradeParamDto 
    {
        public int Id { get;  set; }
        public int Order { get; set; }
        public string Section { get;  set; }
        public Decimal MaxMarks { get;  set; }

    }
}
