using Qface.Domain.Shared.Common;
using Qface.Domain.Shared.ValueObjects;
using QIMSchoolPro.Thesis.Domain.Enums;
using QIMSchoolPro.Thesis.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QIMSchoolPro.Thesis.Domain.Entities
{
    public class AcademicConfiguration : AuditableAutoEntity
    {
        public AcademicPeriod AcademicPeriod { get; set; }
        public bool Active { get; set; }
        public AcademicPeriodActivity OngoingActivity { get; set; }

        public AcademicConfigurationGroup Group { get; set; }
    }
}
