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
using Version = QIMSchoolPro.Thesis.Domain.Entities.Version;

namespace QIMSchoolPro.Thesis.Persistence.Repositories
{
    public class VersionRepository : Repository<Version>, IVersionRepository
    {
        public ILogger<Version> Logger { get; }

        public VersionRepository(ThesisDbContext context, ILogger<Version> logger): base(context)
        {
            Logger = logger;
        }


        public async Task<List<Version>> GetVersionsByDocumentId(int id) 
        { 
            return  GetBaseQuery().Where(a=>a.DocumentId == id).ToList();
        }


        public override IQueryable<Version> GetBaseQuery()
        {
            return base.GetBaseQuery();
                

        }

    }
}
