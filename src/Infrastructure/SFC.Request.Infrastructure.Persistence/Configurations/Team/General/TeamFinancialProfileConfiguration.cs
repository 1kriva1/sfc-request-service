using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Request.Domain.Entities.Team.General;
using SFC.Request.Infrastructure.Persistence.Constants;

namespace SFC.Request.Infrastructure.Persistence.Configurations.Team.General;
public class TeamFinancialProfileConfiguration : IEntityTypeConfiguration<TeamFinancialProfile>
{
    public void Configure(EntityTypeBuilder<TeamFinancialProfile> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.Property(e => e.FreePlay)
            .HasDefaultValue(false);

        builder.ToTable("FinancialProfiles", DatabaseConstants.TeamSchemaName);
    }
}