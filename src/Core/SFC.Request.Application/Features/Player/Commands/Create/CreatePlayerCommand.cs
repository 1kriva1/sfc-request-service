using SFC.Request.Application.Common.Dto.Player.General;
using SFC.Request.Application.Common.Enums;
using SFC.Request.Application.Features.Common.Base;

namespace SFC.Request.Application.Features.Player.Commands.Create;
public class CreatePlayerCommand : ParentRequest
{
    public override RequestId RequestId { get => RequestId.CreatePlayer; }

    public PlayerDto Player { get; set; } = null!;
}