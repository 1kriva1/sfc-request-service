using SFC.Request.Messages.Models.Common;

namespace SFC.Request.Messages.Models.Request.Game.Team;

public class GameTeamRequest : Auditable
{
    public long Id { get; set; }

    public Guid UserId { get; set; }

    public long GameId { get; set; }

    public long TeamId { get; set; }

    public int StatusId { get; set; }

    public string? GameComment { get; set; }

    public required string TeamComment { get; set; }
}