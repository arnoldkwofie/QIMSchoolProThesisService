using QIMSchoolPro.Thesis.Domain.Entities;
using QIMSchoolPro.Thesis.Persistence.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Version = QIMSchoolPro.Thesis.Domain.Entities.Version;

namespace QIMSchoolPro.Thesis.Persistence.Interfaces
{
    public interface IThesisAssignmentRepository : IRepository<ThesisAssignment>
    {
        Task<List<ThesisAssignment>> GetByStaffId(int staffId);
    }
}
