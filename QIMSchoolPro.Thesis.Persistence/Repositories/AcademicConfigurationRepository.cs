using Microsoft.Extensions.Logging;

using QIMSchoolPro.Thesis.Domain.Entities;
using QIMSchoolPro.Thesis.Persistence.Interfaces;
using QIMSchoolPro.Thesis.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace QIMSchoolPro.Thesis.Persistence.Repositories
{
    public class AcademicConfigurationRepository : Repository<AcademicConfiguration>, IAcademicConfigurationRepository
    {
        public ILogger<AcademicConfiguration> Logger { get; }

        public AcademicConfigurationRepository(ThesisDbContext context, ILogger<AcademicConfiguration> logger): base(context)
        {
            Logger = logger;
        }

        public async Task<AcademicConfiguration> GetAcademicPeriodsAsync()
        {
           
                var academicYear = await GetBaseQuery().FirstOrDefaultAsync(a => a.Active);
                return academicYear;

        }

    }
}
