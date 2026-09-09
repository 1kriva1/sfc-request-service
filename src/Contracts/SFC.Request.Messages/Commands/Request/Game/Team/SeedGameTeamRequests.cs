using SFC.Request.Messages.Commands.Common;
using SFC.Request.Messages.Models.Request.Game.Team;

namespace SFC.Request.Messages.Commands.Request.Game.Team;
public class SeedGameTeamRequests : InitiatorCommand
{
    public IEnumerable<GameTeamRequest> GameTeamRequests { get; init; } = [];
}