using SFC.Request.Domain.Common.Interfaces;

namespace SFC.Request.Domain.Entities.Request.Team.Player;
public class TeamPlayerRequest : RequestEntity, IPlayerEntity, ITeamEntity
{
    public long TeamId { get; set; }

    public TeamEntity Team { get; set; } = default!;

    public string? TeamComment { get; set; }

    public long PlayerId { get; set; }

    public PlayerEntity Player { get; set; } = default!;

    public required string PlayerComment { get; set; }
}