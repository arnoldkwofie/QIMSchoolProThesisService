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
    public class StaffDto 
    {
        public string StaffNumber { get; private set; }
        public string ProfileUrl { get; private set; }
        public int DepartmentId { get; private set; }
        public PartyDto Party { get; set; }
        public int PartyId { get; set; }

    }
}
