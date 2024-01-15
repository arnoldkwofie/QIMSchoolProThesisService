using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using QIMSchoolPro.Thesis.Domain.Entities;
using QIMSchoolPro.Thesis.Persistence.Interfaces;
using QIMSchoolPro.Thesis.Persistence.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace QIMSchoolPro.Thesis.Persistence.Repositories
{
    public class StaffRepository : Repository<Staff>, IStaffRepository
    {
        public ILogger<Staff> Logger { get; }

        public StaffRepository(ThesisDbContext context, ILogger<Staff> logger): base(context)
        {
            Logger = logger;
        }


        public async Task<Staff> GetStaffByEmail(string email)
        {
            return GetBaseQuery().Where(a => a.Party.PrimaryEmailAddress.Email.Value == email).FirstOrDefault();
        }

        public async Task<List<Staff>> GetStaffInDepartment(int departmentId)
        { 
          var data= GetBaseQuery().Where(a=>a.DepartmentId==departmentId).ToList();
            return data;
        }

        public override IQueryable<Staff> GetBaseQuery()
        {
            return base.GetBaseQuery()
                .Include(a => a.Party);

        }

    }
}
