using SFC.Request.Domain.Common.Interfaces;

namespace SFC.Request.Domain.Entities.Request.Game.Team;
public class GameTeamRequest : RequestEntity, ITeamEntity, IGameEntity
{
    public long GameId { get; set; }

    public GameEntity Game { get; set; } = default!;

    public string? GameComment { get; set; }

    public long TeamId { get; set; }

    public TeamEntity Team { get; set; } = default!;

    public required string TeamComment { get; set; }
}