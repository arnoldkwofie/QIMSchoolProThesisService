using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Qface.Domain.Shared.ValueObjects;
using QIMSchoolPro.Thesis.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qface.Domain.Shared.Enums;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace QIMSchoolPro.Thesis.Persistence.Configurations
{
	public class StaffConfiguration : IEntityTypeConfiguration<Staff>
	{
		public void Configure(EntityTypeBuilder<Staff> builder)
		{
			builder.ToTable(nameof(Staff));
			builder.OwnsOne<Audit>(typeof(Audit).Name);

			//builder.Ignore(a => a.PhotoUrl);

			builder.Ignore(a => a.ProfileUrl);
			builder.OwnsOne(e => e.Audit, b =>
			{
				b.Property(e => e.EntityStatus).HasConversion(new EnumToStringConverter<EntityStatus>());
			}); builder.HasQueryFilter(a => a.Audit.EntityStatus == EntityStatus.Normal);

		}
	}
}
