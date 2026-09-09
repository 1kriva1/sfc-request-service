using SFC.Request.Domain.Common;

namespace SFC.Request.Domain.Entities.Game.Data;
public class GamePlayerStatus : EnumDataEntity<GamePlayerStatusEnum>
{
    public GamePlayerStatus() : base() { }

    public GamePlayerStatus(GamePlayerStatusEnum enumType) : base(enumType) { }
}