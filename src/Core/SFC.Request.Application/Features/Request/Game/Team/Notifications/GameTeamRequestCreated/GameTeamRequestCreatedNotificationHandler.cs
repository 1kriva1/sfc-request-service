using MediatR;

using SFC.Request.Application.Interfaces.Request.Game.Team;
using SFC.Request.Domain.Events.Request.Game.Team;

namespace SFC.Request.Application.Features.Request.Game.Team.Notifications.GameTeamRequestCreated;
public class GameTeamRequestCreatedNotificationHandler(IGameTeamRequestService gameTeamRequestService) : INotificationHandler<GameTeamRequestCreatedEvent>
{
    private readonly IGameTeamRequestService _gameTeamRequestService = gameTeamRequestService;

    public Task Handle(GameTeamRequestCreatedEvent notification, CancellationToken cancellationToken)
    {
        return _gameTeamRequestService.NotifyGameTeamRequestCreatedAsync(notification.Request, cancellationToken);
    }
}