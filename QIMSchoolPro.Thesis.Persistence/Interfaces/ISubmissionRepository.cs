using QIMSchoolPro.Thesis.Domain.Entities;
using QIMSchoolPro.Thesis.Persistence.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QIMSchoolPro.Thesis.Persistence.Interfaces
{
    public interface ISubmissionRepository : IRepository<Submission>
    {
        Task<List<Submission>> GetUserSubmissions(string studentNumber);
        Task<Submission> Get(int id);
        Task<List<Submission>> GetSPSSubmissions();
        Task<List<Submission>> GetDepartmentSubmissions(int departmentId);
        Task<List<Submission>> GetDepartmentProcessedReviews(int departmentId);
        Task<List<Submission>> GetSPSProcessedReviews();
        Task<List<Submission>> GetReportSubmissions();
        Task<List<Submission>> GetStudentReportSubmissions(string username);
        Task<List<Submission>> GetDepartmentReportSubmissions(int departmentId);
    }
}
