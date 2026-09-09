using AutoMapper;

using MassTransit;

using SFC.Request.Application.Interfaces.Request.Game.Player;
using SFC.Request.Domain.Entities.Request.Game.Player;
using SFC.Request.Messages.Events.Request.Game.Player;

namespace SFC.Request.Infrastructure.Services.Request.Game.Player;
public class GamePlayerRequestService(IMapper mapper, IPublishEndpoint publisher) : IGamePlayerRequestService
{
    private readonly IPublishEndpoint _publisher = publisher;
    private readonly IMapper _mapper = mapper;

    public Task NotifyGamePlayerRequestCreatedAsync(GamePlayerRequest request, CancellationToken cancellationToken = default)
    {
        GamePlayerRequestCreated @event = _mapper.Map<GamePlayerRequestCreated>(request);
        return _publisher.Publish(@event, cancellationToken);
    }

    public Task NotifyGamePlayerRequestUpdatedAsync(GamePlayerRequest request, CancellationToken cancellationToken = default)
    {
        GamePlayerRequestUpdated @event = _mapper.Map<GamePlayerRequestUpdated>(request);
        return _publisher.Publish(@event, cancellationToken);
    }
}