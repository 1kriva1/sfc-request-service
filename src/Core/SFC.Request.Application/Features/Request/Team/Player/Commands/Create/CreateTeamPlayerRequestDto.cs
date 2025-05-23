using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Domain.Entities.Request.Team.Player;

namespace SFC.Request.Application.Features.Request.Team.Player.Commands.Create;
public class CreateTeamPlayerRequestDto : IMapTo<TeamPlayerRequest>
{
    public long TeamId { get; set; }

    public long PlayerId { get; set; }

    public required string PlayerComment { get; set; }
}