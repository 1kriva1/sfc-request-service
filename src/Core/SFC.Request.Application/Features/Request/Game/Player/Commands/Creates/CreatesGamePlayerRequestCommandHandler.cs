using AutoMapper;

using MediatR;

using SFC.Request.Application.Features.Request.Game.Player.Common.Extensions;
using SFC.Request.Application.Interfaces.Persistence.Repository.Request.Game.Player;
using SFC.Request.Domain.Entities.Request.Game.Player;
using SFC.Request.Domain.Events.Request.Game.Player;

namespace SFC.Request.Application.Features.Request.Game.Player.Commands.Creates;
public class CreateGamePlayerRequestsCommandHandler(IMapper mapper, IGamePlayerRequestRepository gamePlayerRequestRepository)
    : IRequestHandler<CreatesGamePlayerRequestCommand, CreatesGamePlayerRequestViewModel>
{
    private readonly IMapper _mapper = mapper;
    private readonly IGamePlayerRequestRepository _gamePlayerRequestRepository = gamePlayerRequestRepository;

    public async Task<CreatesGamePlayerRequestViewModel> Handle(CreatesGamePlayerRequestCommand request, CancellationToken cancellationToken)
    {
        GamePlayerRequest[] gamePlayerRequests = [.. request.Requests.Select(MapGamePlayerRequest)];

        await _gamePlayerRequestRepository.AddRangeAsync(gamePlayerRequests)
                                         .ConfigureAwait(false);

        IEnumerable<GamePlayerRequest> result = await _gamePlayerRequestRepository
            .GetByIdsAsync(gamePlayerRequests.Select(i => i.Id))
            .ConfigureAwait(true);

        return _mapper.Map<CreatesGamePlayerRequestViewModel>(result);
    }

    private GamePlayerRequest MapGamePlayerRequest(CreatesGamePlayerRequestDto request)
    {
        GamePlayerRequest entity = _mapper.Map<GamePlayerRequest>(request)
                                         .SetStatus(RequestStatusEnum.Actual);

        entity.AddDomainEvent(new GamePlayerRequestCreatedEvent(entity));

        return entity;
    }
}