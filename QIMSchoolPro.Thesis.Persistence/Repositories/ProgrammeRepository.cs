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
    public class ProgrammeRepository : Repository<Programme>, IProgrammeRepository
    {
        public ILogger<Programme> Logger { get; }

        public ProgrammeRepository(ThesisDbContext context, ILogger<Programme> logger): base(context)
        {
            Logger = logger;
        }


      

        public override IQueryable<Programme> GetBaseQuery()
        {
            return base.GetBaseQuery()
                .Include(a => a.Department);

        }

    }
}
