using AutoMapper;

using MassTransit;

using SFC.Request.Application.Interfaces.Request.Team.Player;
using SFC.Request.Domain.Entities.Request.Team.Player;
using SFC.Request.Messages.Events.Request.Team.Player;

namespace SFC.Request.Infrastructure.Services.Request.Team.Player;
public class TeamPlayerRequestService(IMapper mapper, IPublishEndpoint publisher) : ITeamPlayerRequestService
{
    private readonly IPublishEndpoint _publisher = publisher;
    private readonly IMapper _mapper = mapper;

    public Task NotifyTeamPlayerRequestCreatedAsync(TeamPlayerRequest request, CancellationToken cancellationToken = default)
    {
        TeamPlayerRequestCreated @event = _mapper.Map<TeamPlayerRequestCreated>(request);
        return _publisher.Publish(@event, cancellationToken);
    }

    public Task NotifyTeamPlayerRequestUpdatedAsync(TeamPlayerRequest request, CancellationToken cancellationToken = default)
    {
        TeamPlayerRequestUpdated @event = _mapper.Map<TeamPlayerRequestUpdated>(request);
        return _publisher.Publish(@event, cancellationToken);
    }
}