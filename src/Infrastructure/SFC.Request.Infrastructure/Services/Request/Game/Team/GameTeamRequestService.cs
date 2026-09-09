using AutoMapper;

using MassTransit;

using SFC.Request.Application.Interfaces.Request.Game.Team;
using SFC.Request.Domain.Entities.Request.Game.Team;
using SFC.Request.Messages.Events.Request.Game.Team;

namespace SFC.Request.Infrastructure.Services.Request.Game.Team;
public class GameTeamRequestService(IMapper mapper, IPublishEndpoint publisher) : IGameTeamRequestService
{
    private readonly IPublishEndpoint _publisher = publisher;
    private readonly IMapper _mapper = mapper;

    public Task NotifyGameTeamRequestCreatedAsync(GameTeamRequest request, CancellationToken cancellationToken = default)
    {
        GameTeamRequestCreated @event = _mapper.Map<GameTeamRequestCreated>(request);
        return _publisher.Publish(@event, cancellationToken);
    }

    public Task NotifyGameTeamRequestUpdatedAsync(GameTeamRequest request, CancellationToken cancellationToken = default)
    {
        GameTeamRequestUpdated @event = _mapper.Map<GameTeamRequestUpdated>(request);
        return _publisher.Publish(@event, cancellationToken);
    }
}