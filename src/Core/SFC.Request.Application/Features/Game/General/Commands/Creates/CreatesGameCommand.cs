using SFC.Request.Application.Common.Dto.Game.General;
using SFC.Request.Application.Common.Enums;

namespace SFC.Request.Application.Features.Game.General.Commands.Creates;
public class CreatesGameCommand : ParentRequest
{
    public override RequestId RequestId { get => RequestId.CreateGames; }

    public IEnumerable<GameDto> Games { get; set; } = null!;
}