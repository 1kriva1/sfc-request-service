using SFC.Request.Application.Features.Request.Game.Player.Commands.Update;
using SFC.Request.Application.Features.Request.Game.Team.Commands.Update;
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

    public static UpdateGamePlayerRequestCommand BuildUpdateGamePlayerRequestCommand(this RequestStatusEnum status, long id, long gameId, long playerId)
    {
        return new()
        {
            Request = new UpdateGamePlayerRequestDto
            {
                Id = id,
                GameId = gameId,
                PlayerId = playerId,
                Status = (int)status
            }
        };
    }

    public static UpdateGameTeamRequestCommand BuildUpdateGameTeamRequestCommand(this RequestStatusEnum status, long id, long gameId, long teamId)
    {
        return new()
        {
            Request = new UpdateGameTeamRequestDto
            {
                Id = id,
                GameId = gameId,
                TeamId = teamId,
                Status = (int)status
            }
        };
    }
}