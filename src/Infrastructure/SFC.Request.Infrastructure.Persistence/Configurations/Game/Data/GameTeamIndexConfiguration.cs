using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Request.Domain.Entities.Game.Data;
using SFC.Request.Infrastructure.Persistence.Configurations.Base;
using SFC.Request.Infrastructure.Persistence.Constants;

namespace SFC.Request.Infrastructure.Persistence.Configurations.Game.Data;
public class GameTeamIndexConfiguration : EnumDataEntityConfiguration<GameTeamIndex, GameTeamIndexEnum>
{
    public override void Configure(EntityTypeBuilder<GameTeamIndex> builder)
    {
        builder.ToTable("TeamIndexes", DatabaseConstants.GameSchemaName);
        base.Configure(builder);
    }
}