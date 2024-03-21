using Microsoft.Extensions.Logging;
using QIMSchoolPro.Thesis.Domain.Entities;
using QIMSchoolPro.Thesis.Persistence.Interfaces;
using QIMSchoolPro.Thesis.Persistence.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Version = QIMSchoolPro.Thesis.Domain.Entities.Version;

namespace QIMSchoolPro.Thesis.Persistence.Repositories
{
    public class ExaminerReportRepository : Repository<ExaminerReport>, IExaminerReportRepository
    {
        public ILogger<ExaminerReport> Logger { get; }

        public ExaminerReportRepository(ThesisDbContext context, ILogger<ExaminerReport> logger): base(context)
        {
            Logger = logger;
        }

        public override IQueryable<ExaminerReport> GetBaseQuery()
        {
            return base.GetBaseQuery();
        }

    }
}
