using SFC.Request.Application.Common.Dto.Player.General;
using SFC.Request.Application.Common.Enums;
using SFC.Request.Application.Features.Common.Base;

namespace SFC.Request.Application.Features.Player.Commands.CreateRange;
public class CreatePlayersCommand : ParentRequest
{
    public override RequestId RequestId { get => RequestId.CreatePlayers; }

    public IEnumerable<PlayerDto> Players { get; set; } = null!;
}