using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Request.Domain.Entities.Game.Data;
using SFC.Request.Infrastructure.Persistence.Configurations.Base;
using SFC.Request.Infrastructure.Persistence.Constants;

namespace SFC.Request.Infrastructure.Persistence.Configurations.Game.Data;
public class GamePlayerStatusConfiguration : EnumDataEntityConfiguration<GamePlayerStatus, GamePlayerStatusEnum>
{
    public override void Configure(EntityTypeBuilder<GamePlayerStatus> builder)
    {
        builder.ToTable("GamePlayerStatuses", DatabaseConstants.GameSchemaName);
        base.Configure(builder);
    }
}