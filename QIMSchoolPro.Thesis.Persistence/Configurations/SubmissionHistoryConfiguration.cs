using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Qface.Domain.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QIMSchoolPro.Thesis.Domain.Entities;
using Qface.Domain.Shared.Enums;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QIMSchoolPro.Thesis.Domain.ValueObjects;
using Version = QIMSchoolPro.Thesis.Domain.Entities.Version;

namespace QIMSchoolPro.Thesis.Persistence.Configurations
{
    public class SubmissionHistoryConfiguration : IEntityTypeConfiguration<SubmissionHistory>
    {
        public void Configure(EntityTypeBuilder<SubmissionHistory> builder)
        {
            builder.ToTable(nameof(SubmissionHistory));
            builder.OwnsOne<Audit>(typeof(Audit).Name);
            builder.OwnsOne(e => e.Audit, b =>
            {
                b.Property(e => e.EntityStatus).HasConversion(new EnumToStringConverter<EntityStatus>());
            });
            builder.HasQueryFilter(a => a.Audit.EntityStatus == EntityStatus.Normal);
        }
    }
}
