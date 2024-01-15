using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using QIMSchoolPro.Thesis.Domain.Entities;
using QIMSchoolPro.Thesis.Domain.Enums;
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

        public async Task<List<Submission>> GetUserSubmissions(string studentNumber)
        {
            return await GetBaseQuery().Where(a=>a.StudentNumber==studentNumber).ToListAsync();
        }

        public async Task<List<Submission>> GetDepartmentSubmissions(int departmentId)
        {
            var data = await GetBaseQuery().Where(a => a.Student.Programme.Department.Id == departmentId && a.TransitionState == TransitionState.Department_Review).ToListAsync();

            return data;
        }

        public async Task<List<Submission>> GetSPSSubmissions()
        {
            var data = await GetBaseQuery().Where(a=> a.TransitionState == TransitionState.SPS_Review).ToListAsync();

            return data;
        }
        public async Task<Submission> Get(int id)
        {
            return await GetBaseQuery().Where(a => a.Id == id).FirstOrDefaultAsync();
        }

        public override IQueryable<Submission> GetBaseQuery()
        {
            var data = base.GetBaseQuery()
                .Include(a => a.Documents).ThenInclude(a => a.Versions)
                .Include(a => a.SubmissionHistories)
                .Include(a => a.Student).ThenInclude(a => a.Programme).ThenInclude(a => a.Department)
                .Include(a => a.Student).ThenInclude(a => a.Party);
            
               return data;
        }

    }
}
