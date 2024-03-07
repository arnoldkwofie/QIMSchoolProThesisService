using Qface.Domain.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QIMSchoolPro.Thesis.Domain.Entities
{
    public class GradeParam : AuditableAutoEntity
    {
        public int Id { get; private set; }
        public int Order { get; set; }
        public string Section { get; private set; }
        public Decimal MaxMarks { get; private set; }

    }
}
