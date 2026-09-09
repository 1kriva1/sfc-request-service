using SFC.Request.Domain.Common;

namespace SFC.Request.Domain.Entities.Game.Data;
public class GameStatus : EnumDataEntity<GameStatusEnum>
{
    public GameStatus() : base() { }

    public GameStatus(GameStatusEnum enumType) : base(enumType) { }
}