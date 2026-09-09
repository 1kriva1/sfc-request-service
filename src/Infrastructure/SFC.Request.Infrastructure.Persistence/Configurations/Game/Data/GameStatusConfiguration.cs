using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Request.Domain.Entities.Game.Data;
using SFC.Request.Infrastructure.Persistence.Configurations.Base;
using SFC.Request.Infrastructure.Persistence.Constants;

namespace SFC.Request.Infrastructure.Persistence.Configurations.Game.Data;
public class GameStatusConfiguration : EnumDataEntityConfiguration<GameStatus, GameStatusEnum>
{
    public override void Configure(EntityTypeBuilder<GameStatus> builder)
    {
        builder.ToTable("GameStatuses", DatabaseConstants.GameSchemaName);
        base.Configure(builder);
    }
}