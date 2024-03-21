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
    public class OralExaminationRepository : Repository<OralExamination>, IOralExaminationRepository
    {
        public ILogger<OralExamination> Logger { get; }

        public OralExaminationRepository(ThesisDbContext context, ILogger<OralExamination> logger): base(context)
        {
            Logger = logger;
        }

        public async Task<OralExamination> GetBySubmissionId(int id)
        {
            var data = await GetBaseQuery().Where(a=>a.SubmissionId == id).FirstOrDefaultAsync();
            return data;
        }

        public override IQueryable<OralExamination> GetBaseQuery()
        {
            return base.GetBaseQuery()
                .Include(a=>a.Submission).ThenInclude(a=>a.Student).ThenInclude(a=>a.Party)
                .Include(a=>a.Submission).ThenInclude(a=>a.Student).ThenInclude(a=>a.Programme).ThenInclude(a=>a.Department);
        }

    }
}
