using MediatR;

using SFC.Request.Application.Interfaces.Request.Team.Player;
using SFC.Request.Domain.Events.Request.Team.Player;

namespace SFC.Request.Application.Features.Request.Team.Player.Notifications.RequestCreated;
public class RequestCreatedNotificationHandler(ITeamPlayerRequestService requestService) : INotificationHandler<TeamPlayerRequestCreatedEvent>
{
    private readonly ITeamPlayerRequestService _requestService = requestService;

    public Task Handle(TeamPlayerRequestCreatedEvent notification, CancellationToken cancellationToken)
    {
        return _requestService.NotifyTeamPlayerRequestCreatedAsync(notification.Request, cancellationToken);
    }
}