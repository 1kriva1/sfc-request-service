using SFC.Request.Domain.Common;
using SFC.Request.Domain.Entities.Data;

namespace SFC.Request.Domain.Events.Data;

public class DataResetedEvent(
    IEnumerable<FootballPosition> footballPositions,
    GameStyle[] gameStyles,
    WorkingFoot[] workingFoots,
    StatType[] statTypes
    ) : BaseEvent
{
    public IEnumerable<FootballPosition> FootballPositions { get; } = footballPositions;

    public IEnumerable<GameStyle> GameStyles { get; } = gameStyles;

    public IEnumerable<WorkingFoot> WorkingFoots { get; } = workingFoots;

    public IEnumerable<StatType> StatTypes { get; } = statTypes;
}