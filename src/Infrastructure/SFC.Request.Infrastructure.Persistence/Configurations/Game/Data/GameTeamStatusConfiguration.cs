using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Request.Domain.Entities.Game.Data;
using SFC.Request.Infrastructure.Persistence.Configurations.Base;
using SFC.Request.Infrastructure.Persistence.Constants;

namespace SFC.Request.Infrastructure.Persistence.Configurations.Game.Data;
public class GameTeamStatusConfiguration : EnumDataEntityConfiguration<GameTeamStatus, GameTeamStatusEnum>
{
    public override void Configure(EntityTypeBuilder<GameTeamStatus> builder)
    {
        builder.ToTable("TeamStatuses", DatabaseConstants.GameSchemaName);
        base.Configure(builder);
    }
}