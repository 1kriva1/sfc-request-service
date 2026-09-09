using SFC.Request.Application.Common.Enums;
using SFC.Request.Application.Features.Game.Data.Common.Dto;

namespace SFC.Request.Application.Features.Game.Data.Commands.Reset;
public class ResetGameDataCommand : ParentRequest
{
    public override RequestId RequestId { get => RequestId.ResetGameData; }

    public IEnumerable<GameStatusDto> GameStatuses { get; init; } = [];

    public IEnumerable<GamePlayerStatusDto> GamePlayerStatuses { get; init; } = [];

    public IEnumerable<GameTeamStatusDto> GameTeamStatuses { get; init; } = [];

    public IEnumerable<GameTeamIndexDto> GameTeamIndexes { get; init; } = [];
}