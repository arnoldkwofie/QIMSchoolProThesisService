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
    public class GradeRepository : Repository<Grade>, IGradeRepository
    {
        public ILogger<Grade> Logger { get; }

        public GradeRepository(ThesisDbContext context, ILogger<Grade> logger) : base(context)
        {
            Logger = logger;
        }


    }
}
