using SFC.Request.Application.Common.Dto.Player.General;
using SFC.Request.Application.Common.Enums;
using SFC.Request.Application.Features.Common.Base;

namespace SFC.Request.Application.Features.Player.Commands.Update;
public class UpdatePlayerCommand : ParentRequest
{
    public override RequestId RequestId { get => RequestId.UpdatePlayer; }

    public PlayerDto Player { get; set; } = null!;
}