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
    public class SubmissionRepository : Repository<Submission>, ISubmissionRepository
    {
        public ILogger<Submission> Logger { get; }

        public SubmissionRepository(ThesisDbContext context, ILogger<Submission> logger): base(context)
        {
            Logger = logger;
        }

        public async Task<List<Submission>> GetUserSubmissions()
        {
            return await GetBaseQuery().ToListAsync();
        }

        public async Task<Submission> Get(int id)
        {
            return await GetBaseQuery().Where(a => a.Id == id).FirstOrDefaultAsync();
        }

        public override IQueryable<Submission> GetBaseQuery()
        {
            return base.GetBaseQuery()
                .Include(a => a.Documents).ThenInclude(a => a.Versions)
                .Include(a=>a.SubmissionHistories);
               
        }

    }
}
