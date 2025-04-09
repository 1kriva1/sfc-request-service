using SFC.Request.Domain.Common;

namespace SFC.Request.Domain.Entities.Data;
public class GameStyle : EnumDataEntity<GameStyleEnum>
{
    public GameStyle() : base() { }

    public GameStyle(GameStyleEnum enumType) : base(enumType) { }
}