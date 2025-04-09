using SFC.Request.Messages.Models.Data;

namespace SFC.Request.Messages.Commands.Team.Data;
public record InitializeData
{
    public IEnumerable<DataValue> TeamPlayerStatuses { get; init; } = [];
}