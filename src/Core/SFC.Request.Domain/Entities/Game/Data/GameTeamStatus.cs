using SFC.Request.Domain.Common;

namespace SFC.Request.Domain.Entities.Game.Data;
public class GameTeamStatus : EnumDataEntity<GameTeamStatusEnum>
{
    public GameTeamStatus() : base() { }

    public GameTeamStatus(GameTeamStatusEnum enumType) : base(enumType) { }
}