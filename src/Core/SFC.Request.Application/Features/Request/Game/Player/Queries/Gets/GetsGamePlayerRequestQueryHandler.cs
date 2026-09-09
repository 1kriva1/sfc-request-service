using AutoMapper;

using MediatR;

using SFC.Request.Application.Interfaces.Persistence.Repository.Request.Game.Player;
using SFC.Request.Domain.Entities.Request.Game.Player;

namespace SFC.Request.Application.Features.Request.Game.Player.Queries.Gets;
public class GetsGamePlayerRequestQueryHandler(IMapper mapper, IGamePlayerRequestRepository gamePlayerRequestRepository)
    : IRequestHandler<GetsGamePlayerRequestQuery, GetsGamePlayerRequestViewModel>
{
    private readonly IMapper _mapper = mapper;
    private readonly IGamePlayerRequestRepository _gamePlayerRequestRepository = gamePlayerRequestRepository;

    public async Task<GetsGamePlayerRequestViewModel> Handle(GetsGamePlayerRequestQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<GamePlayerRequest> GamePlayerRequests = await _gamePlayerRequestRepository.ListAllAsync(request.GameId).ConfigureAwait(true);
        return _mapper.Map<GetsGamePlayerRequestViewModel>(GamePlayerRequests);
    }
}