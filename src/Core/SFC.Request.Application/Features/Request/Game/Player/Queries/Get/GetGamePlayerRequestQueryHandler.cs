using AutoMapper;

using MediatR;

using SFC.Request.Application.Common.Constants;
using SFC.Request.Application.Common.Exceptions;
using SFC.Request.Application.Interfaces.Persistence.Repository.Request.Game.Player;
using SFC.Request.Domain.Entities.Request.Game.Player;

namespace SFC.Request.Application.Features.Request.Game.Player.Queries.Get;
public class GetGamePlayerRequestQueryHandler(IMapper mapper, IGamePlayerRequestRepository gamePlayerRequestRepository)
    : IRequestHandler<GetGamePlayerRequestQuery, GetGamePlayerRequestViewModel>
{
    private readonly IMapper _mapper = mapper;
    private readonly IGamePlayerRequestRepository _gamePlayerRequestRepository = gamePlayerRequestRepository;

    public async Task<GetGamePlayerRequestViewModel> Handle(GetGamePlayerRequestQuery request, CancellationToken cancellationToken)
    {
        GamePlayerRequest Request = await _gamePlayerRequestRepository
            .GetByIdAsync(request.Id, request.GameId, request.PlayerId).ConfigureAwait(true)
                ?? throw new NotFoundException(Localization.RequestNotFound);

        return _mapper.Map<GetGamePlayerRequestViewModel>(Request);
    }
}