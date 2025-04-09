using SFC.Request.Domain.Common;
using SFC.Request.Domain.Common.Interfaces;

namespace SFC.Request.Domain.Entities.Team.Player;
public class TeamPlayer : BaseAuditableReferenceEntity<long>, IUserEntity, IPlayerEntity, ITeamEntity
{
    public Guid UserId { get; set; }

    public long TeamId { get; set; }

    public TeamEntity Team { get; set; } = null!;

    public long PlayerId { get; set; }

    public required PlayerEntity Player { get; set; }

    public TeamPlayerStatusEnum StatusId { get; set; }
}