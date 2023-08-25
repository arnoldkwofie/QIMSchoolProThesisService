using Microsoft.EntityFrameworkCore;
using QIMSchoolPro.Thesis.Domain.Entities;
using Qsmart.EventBus.Shared.Messages.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QIMSchoolPro.Thesis.Persistence
{
    public class ThesisDbContext: DbContext
    {
        public ThesisDbContext(DbContextOptions options)
              : base(options)
        {
        }

        public DbSet<Submission> Submissions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ThesisDbContext).Assembly);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Ignore<DomainEvent>();
        }
    }
}
