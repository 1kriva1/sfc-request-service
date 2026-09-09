using MediatR;

using SFC.Request.Application.Interfaces.Request.Game.Player;
using SFC.Request.Domain.Events.Request.Game.Player;

namespace SFC.Request.Application.Features.Request.Game.Player.Notifications.GamePlayerRequestCreated;
public class GamePlayerRequestCreatedNotificationHandler(IGamePlayerRequestService gamePlayerRequestService) : INotificationHandler<GamePlayerRequestCreatedEvent>
{
    private readonly IGamePlayerRequestService _gamePlayerRequestService = gamePlayerRequestService;

    public Task Handle(GamePlayerRequestCreatedEvent notification, CancellationToken cancellationToken)
    {
        return _gamePlayerRequestService.NotifyGamePlayerRequestCreatedAsync(notification.Request, cancellationToken);
    }
}