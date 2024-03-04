using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Qface.Domain.Shared.ValueObjects;
using QIMSchoolPro.Thesis.Domain.Entities;
using QIMSchoolPro.Thesis.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qface.Domain.Shared.Enums;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace QIMSchoolPro.Thesis.Persistence.Configurations
{
    public class AcademicConfigurationCofig : IEntityTypeConfiguration<AcademicConfiguration>
    {
        public void Configure(EntityTypeBuilder<AcademicConfiguration> builder)
        {
            builder.ToTable(nameof(AcademicConfiguration));
            builder.OwnsOne<Audit>(typeof(Audit).Name);
            builder.OwnsOne<AcademicPeriod>(typeof(AcademicPeriod).Name);
            builder.OwnsOne(a => a.OngoingActivity);
            builder.OwnsOne(e => e.Audit, b =>
            {
                b.Property(e => e.EntityStatus).HasConversion(new EnumToStringConverter<EntityStatus>());
            });
            builder.HasQueryFilter(a => a.Audit.EntityStatus == EntityStatus.Normal);

           
        }
    }
}
