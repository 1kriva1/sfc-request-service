using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Request.Domain.Entities.Team.General;
using SFC.Request.Infrastructure.Persistence.Constants;

namespace SFC.Request.Infrastructure.Persistence.Configurations.Team.General;
public class TeamInventaryProfileConfiguration : IEntityTypeConfiguration<TeamInventaryProfile>
{
    public void Configure(EntityTypeBuilder<TeamInventaryProfile> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.Property(e => e.HasManiches)
            .HasDefaultValue(false);

        builder.ToTable("InventaryProfiles", DatabaseConstants.TeamSchemaName);
    }
}