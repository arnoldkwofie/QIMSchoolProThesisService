using Microsoft.Extensions.Logging;
using QIMSchoolPro.Thesis.Domain.Entities;
using QIMSchoolPro.Thesis.Persistence.Interfaces;
using QIMSchoolPro.Thesis.Persistence.Repositories.Base;

using Version = QIMSchoolPro.Thesis.Domain.Entities.Version;
using Microsoft.EntityFrameworkCore;

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
            return GetBaseQuery().
               Where(a => a.StaffId == staffId).ToList();
        }

        public async Task<List<ThesisAssignment>> GetReviewerReportSubmissions(int staffId)
        {
            var data = await GetBaseQuery().Where(a => a.StaffId == staffId && a.Submission.Publish).ToListAsync();
            return data;
        }

        public async Task<List<ThesisAssignment>> GetBySubmissionId(int submissionId)
        {
            return GetBaseQuery().
               Where(a => a.SubmissionId == submissionId).ToList();
        }

        public override IQueryable<ThesisAssignment> GetBaseQuery()
        {
            return base.GetBaseQuery()
                  .Include(a => a.Staff)
                  .Include(a => a.Submission).ThenInclude(a => a.Student).ThenInclude(a => a.Programme).ThenInclude(a => a.Department)
                  .Include(a => a.Submission).ThenInclude(a => a.Student).ThenInclude(a => a.Programme).ThenInclude(a => a.Certificate)
                  .Include(a => a.Submission).ThenInclude(a => a.Student).ThenInclude(a => a.Party)
                  .Include(a => a.Staff).ThenInclude(a => a.Party)
                  .Include(a => a.Submission).ThenInclude(a => a.Documents).ThenInclude(a => a.Versions)
                  .Include(a=>a.Grades).ThenInclude(a=>a.GradeParam)
                  .Include(a=>a.ExaminerReports);
                

            
        }

    }
}
