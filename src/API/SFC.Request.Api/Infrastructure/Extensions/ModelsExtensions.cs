using SFC.Request.Application.Features.Request.Team.Player.Commands.Update;

namespace SFC.Request.Api.Infrastructure.Extensions;

public static class ModelsExtensions
{
    public static UpdateTeamPlayerRequestCommand BuildUpdateTeamPlayerRequestCommand(this RequestStatusEnum status, long id, long teamId, long playerId)
    {
        return new()
        {
            Request = new UpdateTeamPlayerRequestDto
            {
                Id = id,
                TeamId = teamId,
                PlayerId = playerId,
                Status = (int)status
            }
        };
    }
}