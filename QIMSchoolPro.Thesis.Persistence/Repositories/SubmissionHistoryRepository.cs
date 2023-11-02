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
using Version = QIMSchoolPro.Thesis.Domain.Entities.SubmissionHistory;

namespace QIMSchoolPro.Thesis.Persistence.Repositories
{
    public class SubmissionHistoryRepository : Repository<SubmissionHistory>, ISubmissionHistoryRepository
    {
        public ILogger<SubmissionHistory> Logger { get; }

        public SubmissionHistoryRepository(ThesisDbContext context, ILogger<SubmissionHistory> logger): base(context)
        {
            Logger = logger;
        }


        public async Task<List<SubmissionHistory>> GetSubmissionHistoryBySubmissionId(int id)
        {
            return await GetBaseQuery().Where(a=>a.SubmissionId==id).OrderByDescending(a=>a.Id).ToListAsync();
        }



        public override IQueryable<SubmissionHistory> GetBaseQuery()
        {
            return base.GetBaseQuery();
                

        }

    }
}
