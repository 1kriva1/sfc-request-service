using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Request.Domain.Entities.Game.General;
using SFC.Request.Infrastructure.Persistence.Constants;

namespace SFC.Request.Infrastructure.Persistence.Configurations.Game.General;
public class GameInventaryProfileConfiguration : IEntityTypeConfiguration<GameInventaryProfile>
{
    public void Configure(EntityTypeBuilder<GameInventaryProfile> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.Property(e => e.ShirtsRequired)
            .HasDefaultValue(false);

        builder.ToTable("InventaryProfiles", DatabaseConstants.GameSchemaName);
    }
}