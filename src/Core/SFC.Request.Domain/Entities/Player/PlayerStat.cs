using SFC.Request.Domain.Entities.Data;

namespace SFC.Request.Domain.Entities.Player;
public class PlayerStat : BasePlayerEntity
{
    public StatTypeEnum TypeId { get; set; }

    public required StatType Type { get; set; }

    public byte Value { get; set; }
}