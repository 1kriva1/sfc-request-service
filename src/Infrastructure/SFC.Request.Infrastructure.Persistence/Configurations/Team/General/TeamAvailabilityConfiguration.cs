using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Request.Domain.Entities.Team.General;
using SFC.Request.Infrastructure.Persistence.Constants;

namespace SFC.Request.Infrastructure.Persistence.Configurations.Team.General;
public class TeamAvailabilityConfiguration : IEntityTypeConfiguration<TeamAvailability>
{
    public void Configure(EntityTypeBuilder<TeamAvailability> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.Property(e => e.Day)
               .HasConversion<byte>()
               .IsRequired(true);

        builder.Property(e => e.From)
               .IsRequired(true);

        builder.Property(e => e.To)
               .IsRequired(true);

        builder.ToTable("Availabilities", DatabaseConstants.TeamSchemaName);
    }
}