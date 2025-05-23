using SFC.Request.Domain.Entities.Request.Team.Player;

namespace SFC.Request.Application.Features.Request.Team.Player.Common.Extensions;
public static class TeamPlayerRequestExtension
{
    public static TeamPlayerRequest SetStatus(this TeamPlayerRequest value, RequestStatusEnum status)
    {
        value.StatusId = status;
        return value;
    }
}