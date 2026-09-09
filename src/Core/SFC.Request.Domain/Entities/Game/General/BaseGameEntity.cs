using SFC.Request.Domain.Common;

namespace SFC.Request.Domain.Entities.Game.General;
public abstract class BaseGameEntity : BaseEntity<long>
{
    public GameEntity Game { get; set; } = null!;
}