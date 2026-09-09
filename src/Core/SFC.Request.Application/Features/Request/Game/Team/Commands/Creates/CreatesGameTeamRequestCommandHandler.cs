using AutoMapper;

using MediatR;

using SFC.Request.Application.Features.Request.Game.Team.Common.Extensions;
using SFC.Request.Application.Interfaces.Persistence.Repository.Request.Game.Team;
using SFC.Request.Domain.Entities.Request.Game.Team;
using SFC.Request.Domain.Events.Request.Game.Team;

namespace SFC.Request.Application.Features.Request.Game.Team.Commands.Creates;
public class CreateGameTeamRequestsCommandHandler(IMapper mapper, IGameTeamRequestRepository gameTeamRequestRepository)
    : IRequestHandler<CreatesGameTeamRequestCommand, CreatesGameTeamRequestViewModel>
{
    private readonly IMapper _mapper = mapper;
    private readonly IGameTeamRequestRepository _gameTeamRequestRepository = gameTeamRequestRepository;

    public async Task<CreatesGameTeamRequestViewModel> Handle(CreatesGameTeamRequestCommand request, CancellationToken cancellationToken)
    {
        GameTeamRequest[] requests = [.. request.Requests.Select(MapGameTeamRequest)];

        await _gameTeamRequestRepository.AddRangeAsync(requests)
                                         .ConfigureAwait(false);

        IEnumerable<GameTeamRequest> result = await _gameTeamRequestRepository
            .GetByIdsAsync(requests.Select(i => i.Id))
            .ConfigureAwait(true);

        return _mapper.Map<CreatesGameTeamRequestViewModel>(result);
    }

    private GameTeamRequest MapGameTeamRequest(CreatesGameTeamRequestDto Request)
    {
        GameTeamRequest entity = _mapper.Map<GameTeamRequest>(Request)
                                       .SetStatus(RequestStatusEnum.Actual);

        entity.AddDomainEvent(new GameTeamRequestCreatedEvent(entity));

        return entity;
    }
}