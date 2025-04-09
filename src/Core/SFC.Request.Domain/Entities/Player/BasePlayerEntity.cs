using SFC.Request.Domain.Common;

namespace SFC.Request.Domain.Entities.Player;
public abstract class BasePlayerEntity : BaseEntity<long>
{
    public Player Player { get; set; } = null!;
}