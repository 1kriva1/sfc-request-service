using SFC.Request.Messages.Models.Data;

namespace SFC.Request.Messages.Events.Request.Data;
public record DataInitialized
{
    public IEnumerable<DataValue> RequestStatuses { get; init; } = [];
}