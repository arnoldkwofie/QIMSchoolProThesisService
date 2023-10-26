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
    public class VersionDto 
    {
        public int Id { get; set; }
        public int DocumentId { get; set; }
        public DocumentDto Document { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public AuditDto Audit { get; set; }
    }
}
