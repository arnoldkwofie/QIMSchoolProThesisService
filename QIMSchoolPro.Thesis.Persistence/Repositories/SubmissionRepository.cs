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

        public async Task<List<Submission>> GetDepartmentProcessedReviews(int departmentId)
        {
            var data = await GetBaseQuery().Where(a => a.Student.Programme.Department.Id == departmentId && (a.TransitionState != TransitionState.Department_Review && a.TransitionState != TransitionState.Created)).ToListAsync();

            return data;
        }

      
        public async Task<List<Submission>> GetSPSProcessedReviews()
        {
            var data = await GetBaseQuery().Where(a=>a.TransitionState != TransitionState.SPS_Review && a.TransitionState != TransitionState.Department_Review && a.TransitionState !=TransitionState.Created).ToListAsync();

            return data;
        }

        public async Task<List<Submission>> GetReportSubmissions()
        {
            var data = await GetBaseQuery()
             .Where(a => a.ThesisAssignments.Count(x => x.Assessment) == a.ThesisAssignments.Count() && a.ThesisAssignments.Count() !=0)
             .ToListAsync();


            return data;
        }

        public async Task<List<Submission>> GetStudentReportSubmissions(string username)
        {
            var data = await GetBaseQuery()
             .Where(a => a.ThesisAssignments.Count(x => x.Assessment) == a.ThesisAssignments.Count() &&
             a.ThesisAssignments.Count() != 0 && a.Publish && a.StudentNumber==username)
             .ToListAsync();


            return data;
        }

        public async Task<List<Submission>> GetDepartmentReportSubmissions(int departmentId)
        {
            var data = await GetBaseQuery()
             .Where(a => a.ThesisAssignments.Count(x => x.Assessment) == a.ThesisAssignments.Count() &&
             a.ThesisAssignments.Count() != 0 && a.Publish && a.Student.Programme.Department.Id == departmentId)
             .ToListAsync();


            return data;
        }

        public async Task<List<Submission>> GetLibrarySubmissions()
        {
            var data = await GetBaseQuery().Where(a => a.TransitionState == TransitionState.Library).ToListAsync();

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
                .Include(a => a.SubmissionHistories.OrderByDescending(sh => sh.Id)) // Ordering SubmissionHistories
                .Include(a => a.ThesisAssignments).ThenInclude(a=>a.Staff).ThenInclude(a=>a.Party) // Ordering SubmissionHistories
                .Include(a => a.Student).ThenInclude(a => a.Programme).ThenInclude(a => a.Department)
                .Include(a => a.Student).ThenInclude(a => a.Programme).ThenInclude(a=>a.Certificate)
                .Include(a => a.Student).ThenInclude(a => a.Party);

            return data;
        }

    }
}
