using SFC.Request.Domain.Common;
using SFC.Request.Domain.Common.Interfaces;

namespace SFC.Request.Domain.Entities.Game.Player;

public class GamePlayer : BaseAuditableReferenceEntity<long>, IPlayerEntity, IUserEntity, IGameEntity
{
    public long GameId { get; set; }

    public long PlayerId { get; set; }

    public Guid UserId { get; set; }

    public GamePlayerStatusEnum StatusId { get; set; }

    public GameEntity Game { get; set; } = null!;

    public PlayerEntity Player { get; set; } = default!;
}