using AutoMapper;

using MediatR;

using SFC.Request.Application.Common.Constants;
using SFC.Request.Application.Common.Exceptions;
using SFC.Request.Application.Interfaces.Persistence.Repository.Game.Team;
using SFC.Request.Domain.Entities.Game.Team;

namespace SFC.Request.Application.Features.Game.Team.Commands.Update;
public class UpdateGameTeamHandler(IMapper mapper, IGameTeamRepository gameTeamRepository)
    : IRequestHandler<UpdateGameTeamCommand>
{
    private readonly IMapper _mapper = mapper;
    private readonly IGameTeamRepository _gameTeamRepository = gameTeamRepository;

    public async Task Handle(UpdateGameTeamCommand request, CancellationToken cancellationToken)
    {
        GameTeam gameTeam = await _gameTeamRepository
            .GetByIdAsync(request.GameTeam.GameId, request.GameTeam.TeamId).ConfigureAwait(true)
                ?? throw new NotFoundException(Localization.GameTeamNotFound);

        GameTeam updatedGameTeam = _mapper.Map(request.GameTeam, gameTeam);

        await _gameTeamRepository.UpdateAsync(updatedGameTeam)
                                   .ConfigureAwait(false);
    }
}