using AutoMapper;

using MediatR;

using SFC.Request.Application.Common.Constants;
using SFC.Request.Application.Common.Exceptions;
using SFC.Request.Application.Features.Request.Game.Player.Common.Extensions;
using SFC.Request.Application.Interfaces.Persistence.Repository.Request.Game.Player;
using SFC.Request.Domain.Entities.Request.Game.Player;
using SFC.Request.Domain.Events.Request.Game.Player;

namespace SFC.Request.Application.Features.Request.Game.Player.Commands.Create;
public class CreateGamePlayerRequestCommandHandler(IMapper mapper, IGamePlayerRequestRepository gamePlayerRequestRepository)
    : IRequestHandler<CreateGamePlayerRequestCommand, CreateGamePlayerRequestViewModel>
{
    private readonly IMapper _mapper = mapper;
    private readonly IGamePlayerRequestRepository _gamePlayerRequestRepository = gamePlayerRequestRepository;

    public async Task<CreateGamePlayerRequestViewModel> Handle(CreateGamePlayerRequestCommand request, CancellationToken cancellationToken)
    {
        GamePlayerRequest gamePlayerRequest = _mapper.Map<GamePlayerRequest>(request.Request)
                                         .SetStatus(RequestStatusEnum.Actual);

        gamePlayerRequest.AddDomainEvent(new GamePlayerRequestCreatedEvent(gamePlayerRequest));

        await _gamePlayerRequestRepository.AddAsync(gamePlayerRequest)
                             .ConfigureAwait(false);

        GamePlayerRequest result = await _gamePlayerRequestRepository.GetByIdAsync(gamePlayerRequest.Id)
                         .ConfigureAwait(false) ?? throw new NotFoundException(Localization.RequestNotFound);

        return _mapper.Map<CreateGamePlayerRequestViewModel>(result);
    }
}