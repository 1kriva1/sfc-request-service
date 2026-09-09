using AutoMapper;

using MediatR;

using SFC.Request.Application.Common.Constants;
using SFC.Request.Application.Common.Exceptions;
using SFC.Request.Application.Interfaces.Persistence.Repository.Request.Game.Team;
using SFC.Request.Domain.Entities.Request.Game.Team;
using SFC.Request.Domain.Events.Request.Game.Team;

namespace SFC.Request.Application.Features.Request.Game.Team.Commands.Update;
public class UpdateGameTeamRequestCommandHandler(IMapper mapper, IGameTeamRequestRepository gameTeamRequestRepository)
    : IRequestHandler<UpdateGameTeamRequestCommand>
{
    private readonly IMapper _mapper = mapper;
    private readonly IGameTeamRequestRepository _gameTeamRequestRepository = gameTeamRequestRepository;

    public async Task Handle(UpdateGameTeamRequestCommand request, CancellationToken cancellationToken)
    {
        GameTeamRequest gameTeamRequest = await _gameTeamRequestRepository
             .GetByIdAsync(request.Request.Id, request.Request.GameId, request.Request.TeamId).ConfigureAwait(true)
                 ?? throw new NotFoundException(Localization.RequestNotFound);

        GameTeamRequest updatedRequest = _mapper.Map(request.Request, gameTeamRequest);

        updatedRequest.AddDomainEvent(new GameTeamRequestUpdatedEvent(updatedRequest));

        await _gameTeamRequestRepository.UpdateAsync(updatedRequest)
                                         .ConfigureAwait(false);
    }
}