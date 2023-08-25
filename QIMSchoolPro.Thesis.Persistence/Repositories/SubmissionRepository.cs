using Microsoft.Extensions.Logging;
using QIMSchoolPro.Thesis.Domain.Entities;
using QIMSchoolPro.Thesis.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace QIMSchoolPro.Thesis.Persistence.Repositories
{
    public class SubmissionRepository: ISubmissionRepository
    {
        public ILogger<Submission> Logger { get; }

        public SubmissionRepository(ThesisDbContext context, ILogger<Submission> logger)
        {
            Logger = logger;
        }


        

    }
}
