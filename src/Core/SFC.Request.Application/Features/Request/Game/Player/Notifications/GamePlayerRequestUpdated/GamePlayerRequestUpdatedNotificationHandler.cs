using MediatR;

using SFC.Request.Application.Interfaces.Request.Game.Player;
using SFC.Request.Domain.Events.Request.Game.Player;

namespace SFC.Request.Application.Features.Request.Game.Player.Notifications.GamePlayerRequestUpdated;
public class GamePlayerRequestUpdatedNotificationHandler(IGamePlayerRequestService gamePlayerRequestService) : INotificationHandler<GamePlayerRequestUpdatedEvent>
{
    private readonly IGamePlayerRequestService _gamePlayerRequestService = gamePlayerRequestService;

    public Task Handle(GamePlayerRequestUpdatedEvent notification, CancellationToken cancellationToken)
    {
        return _gamePlayerRequestService.NotifyGamePlayerRequestUpdatedAsync(notification.Request, cancellationToken);
    }
}