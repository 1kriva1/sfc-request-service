using SFC.Request.Messages.Models.Request.Game.Team;

namespace SFC.Request.Messages.Events.Request.Game.Team;
public class GameTeamRequestsSeeded
{
    public IEnumerable<GameTeamRequest> GameTeamRequests { get; init; } = [];
}