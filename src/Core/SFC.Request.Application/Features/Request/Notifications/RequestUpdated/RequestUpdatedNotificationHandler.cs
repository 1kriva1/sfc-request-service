using MediatR;

using SFC.Request.Application.Interfaces.Request;
using SFC.Request.Domain.Events.Request;

namespace SFC.Request.Application.Features.Request.Notifications.RequestUpdated;
public class RequestUpdatedNotificationHandler(IRequestService requestService) : INotificationHandler<RequestUpdatedEvent>
{
    private readonly IRequestService _requestService = requestService;

    public Task Handle(RequestUpdatedEvent notification, CancellationToken cancellationToken)
    {
        return _requestService.NotifyRequestUpdatedAsync(notification.Request, cancellationToken);
    }
}