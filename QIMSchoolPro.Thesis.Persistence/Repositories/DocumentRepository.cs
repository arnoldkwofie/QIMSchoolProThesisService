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
    public class DocumentRepository : Repository<Document>, IDocumentRepository
    {
        public ILogger<Document> Logger { get; }

        public DocumentRepository(ThesisDbContext context, ILogger<Document> logger): base(context)
        {
            Logger = logger;
        }


        public override IQueryable<Document> GetBaseQuery()
        {
            return base.GetBaseQuery().Include(a=>a.Submission);


        }

    }
}
