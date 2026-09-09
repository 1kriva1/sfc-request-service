using SFC.Request.Domain.Common;
using SFC.Request.Domain.Common.Interfaces;
using SFC.Request.Domain.Entities.Game.Player;
using SFC.Request.Domain.Entities.Request.Game.Player;
using SFC.Request.Domain.Entities.Request.Game.Team;

namespace SFC.Request.Domain.Entities.Game.General;

/// <summary>
/// Core entity of the service.
/// </summary>
public class Game : BaseAuditableReferenceEntity<long>, IUserEntity
{
    public Guid UserId { get; set; }

    public GameStatusEnum StatusId { get; set; }

    public required GameGeneralProfile GeneralProfile { get; set; }

    public required GameFinancialProfile FinancialProfile { get; set; }

    public required GameInventaryProfile InventaryProfile { get; set; }

    public required GameAvailability Availability { get; set; }

    public ICollection<GameTag> Tags { get; } = [];

    public ICollection<GamePlayer> Players { get; } = [];

    public ICollection<GamePlayerRequest> PlayerRequests { get; } = [];

    public ICollection<GameTeamRequest> TeamRequests { get; } = [];
}