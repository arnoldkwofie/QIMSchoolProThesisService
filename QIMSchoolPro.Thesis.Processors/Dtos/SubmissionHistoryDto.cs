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
    public class SubmissionHistoryDto 
    {
        public int Id { get; set; }
        public int SubmissionId { get; set; }
        public int PartyId { get; set; }
        public string Activity { get; set; }
        public DateTime ActivityDate { get; set; }

    }
}
