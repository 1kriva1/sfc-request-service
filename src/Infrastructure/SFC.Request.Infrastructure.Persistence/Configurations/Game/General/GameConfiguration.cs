using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Request.Domain.Entities.Game.Data;
using SFC.Request.Domain.Entities.Game.General;
using SFC.Request.Domain.Entities.Identity;
using SFC.Request.Infrastructure.Persistence.Configurations.Base;
using SFC.Request.Infrastructure.Persistence.Constants;

namespace SFC.Request.Infrastructure.Persistence.Configurations.Game.General;
public class GameConfiguration : AuditableReferenceEntityConfiguration<GameEntity, long>
{
    public override void Configure(EntityTypeBuilder<GameEntity> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.HasOne<User>()
               .WithMany()
               .IsRequired(true);

        builder.HasOne<GameStatus>()
               .WithMany()
               .HasForeignKey(t => t.StatusId)
               .IsRequired(true);

        builder.HasOne(e => e.GeneralProfile)
               .WithOne(e => e.Game)
               .HasForeignKey<GameGeneralProfile>()
               .IsRequired(true);

        builder.HasOne(e => e.FinancialProfile)
               .WithOne(e => e.Game)
               .HasForeignKey<GameFinancialProfile>()
               .IsRequired(true);

        builder.HasOne(e => e.InventaryProfile)
               .WithOne(e => e.Game)
               .HasForeignKey<GameInventaryProfile>()
               .IsRequired(true);

        builder.HasOne(e => e.Availability)
               .WithOne(e => e.Game)
               .HasForeignKey<GameAvailability>()
               .IsRequired(true);

        builder.HasMany(e => e.Tags)
               .WithOne(e => e.Game)
               .HasForeignKey(DatabaseConstants.GameForeignKey);

        builder.HasMany(e => e.Players)
               .WithOne(e => e.Game)
               .HasForeignKey(e => e.GameId)
               .OnDelete(DeleteBehavior.ClientCascade);

        builder.ToTable("Games", DatabaseConstants.GameSchemaName);

        base.Configure(builder);
    }
}