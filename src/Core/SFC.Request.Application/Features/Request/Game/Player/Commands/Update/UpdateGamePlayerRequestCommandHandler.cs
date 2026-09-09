using AutoMapper;

using MediatR;

using SFC.Request.Application.Common.Constants;
using SFC.Request.Application.Common.Exceptions;
using SFC.Request.Application.Interfaces.Persistence.Repository.Request.Game.Player;
using SFC.Request.Domain.Entities.Request.Game.Player;
using SFC.Request.Domain.Events.Request.Game.Player;

namespace SFC.Request.Application.Features.Request.Game.Player.Commands.Update;
public class UpdateGamePlayerRequestCommandHandler(IMapper mapper, IGamePlayerRequestRepository gamePlayerRequestRepository)
    : IRequestHandler<UpdateGamePlayerRequestCommand>
{
    private readonly IMapper _mapper = mapper;
    private readonly IGamePlayerRequestRepository _gamePlayerRequestRepository = gamePlayerRequestRepository;

    public async Task Handle(UpdateGamePlayerRequestCommand request, CancellationToken cancellationToken)
    {
        GamePlayerRequest gamePlayerRequest = await _gamePlayerRequestRepository
             .GetByIdAsync(request.Request.Id, request.Request.GameId, request.Request.PlayerId).ConfigureAwait(true)
                 ?? throw new NotFoundException(Localization.RequestNotFound);

        GamePlayerRequest updatedRequest = _mapper.Map(request.Request, gamePlayerRequest);

        updatedRequest.AddDomainEvent(new GamePlayerRequestUpdatedEvent(updatedRequest));

        await _gamePlayerRequestRepository.UpdateAsync(updatedRequest)
                                         .ConfigureAwait(false);
    }
}