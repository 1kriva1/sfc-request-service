using SFC.Request.Domain.Common;

namespace SFC.Request.Domain.Entities.Game.Data;
public class GameTeamIndex : EnumDataEntity<GameTeamIndexEnum>
{
    public GameTeamIndex() : base() { }

    public GameTeamIndex(GameTeamIndexEnum enumType) : base(enumType) { }
}