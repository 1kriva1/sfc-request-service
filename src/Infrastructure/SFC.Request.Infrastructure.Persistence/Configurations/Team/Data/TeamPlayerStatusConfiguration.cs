using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Request.Domain.Entities.Team.Data;
using SFC.Request.Infrastructure.Persistence.Configurations.Base;
using SFC.Request.Infrastructure.Persistence.Constants;

namespace SFC.Request.Infrastructure.Persistence.Configurations.Team.Data;
public class TeamPlayerStatusConfiguration : EnumDataEntityConfiguration<TeamPlayerStatus, TeamPlayerStatusEnum>
{
    public override void Configure(EntityTypeBuilder<TeamPlayerStatus> builder)
    {
        builder.ToTable("PlayerStatuses", DatabaseConstants.TeamSchemaName);
        base.Configure(builder);
    }
}