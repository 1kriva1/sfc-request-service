using SFC.Request.Messages.Models.Data;

namespace SFC.Request.Messages.Commands.Game.Data;
public record InitializeData
{
    public IEnumerable<DataValue> GameStatuses { get; init; } = [];

    public IEnumerable<DataValue> GamePlayerStatuses { get; init; } = [];

    public IEnumerable<DataValue> GameTeamStatuses { get; init; } = [];

    public IEnumerable<DataValue> GameTeamIndexes { get; init; } = [];
}