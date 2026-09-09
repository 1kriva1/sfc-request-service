using AutoMapper;

using MediatR;

using SFC.Request.Application.Common.Constants;
using SFC.Request.Application.Common.Exceptions;
using SFC.Request.Application.Features.Request.Game.Team.Common.Extensions;
using SFC.Request.Application.Interfaces.Persistence.Repository.Request.Game.Team;
using SFC.Request.Domain.Entities.Request.Game.Team;
using SFC.Request.Domain.Events.Request.Game.Team;

namespace SFC.Request.Application.Features.Request.Game.Team.Commands.Create;
public class CreateGameTeamRequestCommandHandler(IMapper mapper, IGameTeamRequestRepository gameTeamRequestRepository)
    : IRequestHandler<CreateGameTeamRequestCommand, CreateGameTeamRequestViewModel>
{
    private readonly IMapper _mapper = mapper;
    private readonly IGameTeamRequestRepository _gameTeamRequestRepository = gameTeamRequestRepository;

    public async Task<CreateGameTeamRequestViewModel> Handle(CreateGameTeamRequestCommand request, CancellationToken cancellationToken)
    {
        GameTeamRequest Request = _mapper.Map<GameTeamRequest>(request.Request)
                                         .SetStatus(RequestStatusEnum.Actual);

        Request.AddDomainEvent(new GameTeamRequestCreatedEvent(Request));

        await _gameTeamRequestRepository.AddAsync(Request)
                             .ConfigureAwait(false);

        GameTeamRequest result = await _gameTeamRequestRepository.GetByIdAsync(Request.Id)
                         .ConfigureAwait(false) ?? throw new NotFoundException(Localization.RequestNotFound);

        return _mapper.Map<CreateGameTeamRequestViewModel>(result);
    }
}