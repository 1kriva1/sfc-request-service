using SFC.Request.Domain.Common;
using SFC.Request.Domain.Common.Interfaces;
using SFC.Request.Domain.Entities.Request.Team.Player;
using SFC.Request.Domain.Entities.Team.Player;

namespace SFC.Request.Domain.Entities.Team.General;
public class Team : BaseAuditableReferenceEntity<long>, IUserEntity
{
    public Guid UserId { get; set; }

    public required TeamGeneralProfile GeneralProfile { get; set; }

    public required TeamFinancialProfile FinancialProfile { get; set; }

    public required TeamInventaryProfile InventaryProfile { get; set; }

    public TeamLogo? Logo { get; set; }

    public ICollection<TeamAvailability> Availability { get; } = [];

    public ICollection<TeamTag> Tags { get; } = [];

    public ICollection<TeamShirt> Shirts { get; } = [];

    public ICollection<TeamPlayer> Players { get; } = [];

    public ICollection<TeamPlayerRequest> PlayerRequests { get; } = [];
}