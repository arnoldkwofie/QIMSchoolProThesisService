using Microsoft.Extensions.Logging;
using QIMSchoolPro.Thesis.Domain.Entities;
using QIMSchoolPro.Thesis.Persistence.Interfaces;
using QIMSchoolPro.Thesis.Persistence.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Version = QIMSchoolPro.Thesis.Domain.Entities.Version;

namespace QIMSchoolPro.Thesis.Persistence.Repositories
{
    public class ThesisAssignmentRepository : Repository<ThesisAssignment>, IThesisAssignmentRepository
    {
        public ILogger<Version> Logger { get; }

        public ThesisAssignmentRepository(ThesisDbContext context, ILogger<Version> logger): base(context)
        {
            Logger = logger;
        }


        public async Task<List<ThesisAssignment>> GetByStaffId(int staffId)
        {
          return  GetBaseQuery().Where(a => a.StaffId == staffId).ToList();
        }

        public override IQueryable<ThesisAssignment> GetBaseQuery()
        {
            return base.GetBaseQuery()
                .Include(a => a.Submission)
                .Include(a => a.Staff);
                

        }

    }
}
