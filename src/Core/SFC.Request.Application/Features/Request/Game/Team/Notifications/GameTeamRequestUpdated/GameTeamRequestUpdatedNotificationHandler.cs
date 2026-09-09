using MediatR;

using SFC.Request.Application.Interfaces.Request.Game.Team;
using SFC.Request.Domain.Events.Request.Game.Team;

namespace SFC.Request.Application.Features.Request.Game.Team.Notifications.GameTeamRequestUpdated;
public class GameTeamRequestUpdatedNotificationHandler(IGameTeamRequestService gameTeamRequestService) : INotificationHandler<GameTeamRequestUpdatedEvent>
{
    private readonly IGameTeamRequestService _gameTeamRequestService = gameTeamRequestService;

    public Task Handle(GameTeamRequestUpdatedEvent notification, CancellationToken cancellationToken)
    {
        return _gameTeamRequestService.NotifyGameTeamRequestUpdatedAsync(notification.Request, cancellationToken);
    }
}