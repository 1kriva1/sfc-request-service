using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Request.Application.Common.Constants;
using SFC.Request.Domain.Entities.Identity;
using SFC.Request.Domain.Entities.Request.Data;
using SFC.Request.Domain.Entities.Request.Game.Player;
using SFC.Request.Infrastructure.Persistence.Configurations.Base;

namespace SFC.Request.Infrastructure.Persistence.Configurations.Request.Game.Player;
public class GamePlayerRequestConfiguration : AuditableEntityConfiguration<GamePlayerRequest, long>
{
    public override void Configure(EntityTypeBuilder<GamePlayerRequest> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        // it's for skip exception during update db (sql server only related)
        builder.HasOne(e => e.Game)
               .WithMany(e => e.PlayerRequests)
               .HasForeignKey(e => e.GameId)
               .OnDelete(DeleteBehavior.ClientCascade);

        // it's for skip exception during update db (sql server only related)
        builder.HasOne(e => e.Player)
               .WithMany(e => e.GameRequests)
               .HasForeignKey(e => e.PlayerId)
               .OnDelete(DeleteBehavior.ClientCascade);

        builder.HasOne<RequestStatus>()
               .WithMany()
               .HasForeignKey(t => t.StatusId)
               .IsRequired(true);

        builder.Property(e => e.GameComment)
               .HasMaxLength(ValidationConstants.DescriptionValueMaxLength)
               .IsRequired(false);

        builder.Property(e => e.PlayerComment)
               .HasMaxLength(ValidationConstants.DescriptionValueMaxLength)
               .IsRequired(true);

        builder.HasOne<User>()
               .WithMany()
               .IsRequired(true);

        builder.ToTable("GamePlayerRequests");

        base.Configure(builder);
    }
}