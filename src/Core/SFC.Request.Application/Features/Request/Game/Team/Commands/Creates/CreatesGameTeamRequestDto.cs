using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Domain.Entities.Request.Game.Team;

namespace SFC.Request.Application.Features.Request.Game.Team.Commands.Creates;
public class CreatesGameTeamRequestDto : IMapTo<GameTeamRequest>
{
    public long GameId { get; set; }

    public long TeamId { get; set; }

    public required string TeamComment { get; set; }
}