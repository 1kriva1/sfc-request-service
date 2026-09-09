using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using SFC.Request.Domain.Entities.Game.Data;
using SFC.Request.Domain.Entities.Game.Team;
using SFC.Request.Domain.Entities.Identity;
using SFC.Request.Infrastructure.Persistence.Configurations.Base;
using SFC.Request.Infrastructure.Persistence.Constants;

namespace SFC.Request.Infrastructure.Persistence.Configurations.Game.Team;
public class GameTeamConfiguration : AuditableReferenceEntityConfiguration<GameTeam, long>
{
    public override void Configure(EntityTypeBuilder<GameTeam> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.HasIndex(t => new { t.GameId, t.TeamId })
               .IsUnique();

        builder.HasOne<GameTeamStatus>()
               .WithMany()
               .HasForeignKey(t => t.StatusId)
               .IsRequired(true);

        builder.HasOne<GameTeamIndex>()
               .WithMany()
               .HasForeignKey(t => t.Index)
               .IsRequired(true);

        builder.HasOne<User>()
               .WithMany()
               .HasForeignKey(t => t.UserId)
               .IsRequired(true)
               .OnDelete(DeleteBehavior.ClientCascade);

        builder.HasOne(t => t.Team)
               .WithMany()
               .HasForeignKey(t => t.TeamId)
               .IsRequired(true)
               .OnDelete(DeleteBehavior.ClientCascade);

        builder.ToTable("Teams", DatabaseConstants.GameSchemaName);

        base.Configure(builder);
    }
}