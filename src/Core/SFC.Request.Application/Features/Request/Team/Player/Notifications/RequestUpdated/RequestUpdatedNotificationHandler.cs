using MediatR;

using SFC.Request.Application.Interfaces.Request.Team.Player;
using SFC.Request.Domain.Events.Request.Team.Player;

namespace SFC.Request.Application.Features.Request.Team.Player.Notifications.RequestUpdated;
public class RequestUpdatedNotificationHandler(ITeamPlayerRequestService requestService) : INotificationHandler<TeamPlayerRequestUpdatedEvent>
{
    private readonly ITeamPlayerRequestService _requestService = requestService;

    public Task Handle(TeamPlayerRequestUpdatedEvent notification, CancellationToken cancellationToken)
    {
        return _requestService.NotifyTeamPlayerRequestUpdatedAsync(notification.Request, cancellationToken);
    }
}