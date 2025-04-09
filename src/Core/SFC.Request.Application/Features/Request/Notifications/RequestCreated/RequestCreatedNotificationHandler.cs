using MediatR;

using SFC.Request.Application.Interfaces.Request;
using SFC.Request.Domain.Events.Request;

namespace SFC.Request.Application.Features.Request.Notifications.RequestCreated;
public class RequestCreatedNotificationHandler(IRequestService requestService) : INotificationHandler<RequestCreatedEvent>
{
    private readonly IRequestService _requestService = requestService;

    public Task Handle(RequestCreatedEvent notification, CancellationToken cancellationToken)
    {
        return _requestService.NotifyRequestCreatedAsync(notification.Request, cancellationToken);
    }
}