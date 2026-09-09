using SFC.Request.Domain.Entities.Request.Game.Team;

namespace SFC.Request.Application.Features.Request.Game.Team.Common.Extensions;
public static class GameTeamRequestExtension
{
    public static GameTeamRequest SetStatus(this GameTeamRequest value, RequestStatusEnum status)
    {
        value.StatusId = status;
        return value;
    }
}