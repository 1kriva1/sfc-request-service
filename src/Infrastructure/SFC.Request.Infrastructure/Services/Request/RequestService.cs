using AutoMapper;

using MassTransit;

using SFC.Request.Application.Interfaces.Request;
using SFC.Request.Messages.Events.Request;

namespace SFC.Request.Infrastructure.Services.Request;
public class RequestService(IMapper mapper, IPublishEndpoint publisher) : IRequestService
{
    private readonly IPublishEndpoint _publisher = publisher;
    private readonly IMapper _mapper = mapper;

    public Task NotifyRequestCreatedAsync(RequestEntity request, CancellationToken cancellationToken = default)
    {
        RequestCreated @event = _mapper.Map<RequestCreated>(request);
        return _publisher.Publish(@event, cancellationToken);
    }

    public Task NotifyRequestUpdatedAsync(RequestEntity request, CancellationToken cancellationToken = default)
    {
        RequestUpdated @event = _mapper.Map<RequestUpdated>(request);
        return _publisher.Publish(@event, cancellationToken);
    }
}