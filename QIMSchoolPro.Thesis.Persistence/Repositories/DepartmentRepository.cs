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
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public ILogger<Department> Logger { get; }

        public DepartmentRepository(ThesisDbContext context, ILogger<Department> logger): base(context)
        {
            Logger = logger;
        }


      

        public override IQueryable<Department> GetBaseQuery()
        {
            return base.GetBaseQuery();
               

        }

    }
}
