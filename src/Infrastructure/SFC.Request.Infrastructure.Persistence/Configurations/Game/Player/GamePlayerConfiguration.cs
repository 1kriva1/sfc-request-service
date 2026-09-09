using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Request.Domain.Entities.Game.Data;
using SFC.Request.Domain.Entities.Game.Player;
using SFC.Request.Domain.Entities.Identity;
using SFC.Request.Infrastructure.Persistence.Configurations.Base;
using SFC.Request.Infrastructure.Persistence.Constants;

namespace SFC.Request.Infrastructure.Persistence.Configurations.Game.Player;
public class GamePlayerConfiguration : AuditableReferenceEntityConfiguration<GamePlayer, long>
{
    public override void Configure(EntityTypeBuilder<GamePlayer> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.HasOne<GamePlayerStatus>()
               .WithMany()
               .HasForeignKey(t => t.StatusId)
               .IsRequired(true);

        builder.HasOne<User>()
               .WithMany()
               .HasForeignKey(t => t.UserId)
               .IsRequired(true)
               .OnDelete(DeleteBehavior.ClientCascade);

        builder.ToTable("Players", DatabaseConstants.GameSchemaName);

        base.Configure(builder);
    }
}