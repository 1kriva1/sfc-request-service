using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Domain.Entities.Request.Game.Player;

namespace SFC.Request.Application.Features.Request.Game.Player.Commands.Creates;
public class CreatesGamePlayerRequestDto : IMapTo<GamePlayerRequest>
{
    public long GameId { get; set; }

    public long PlayerId { get; set; }

    public required string PlayerComment { get; set; }
}