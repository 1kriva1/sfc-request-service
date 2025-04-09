using SFC.Request.Domain.Common;

namespace SFC.Request.Domain.Entities.Player;
public class PlayerAvailableDay : BaseEntity<long>
{
    public PlayerAvailability Availability { get; set; } = null!;

    public DayOfWeek Day { get; set; }
}