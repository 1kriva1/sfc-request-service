using FluentValidation;

using SFC.Request.Application.Common.Constants;
using SFC.Request.Application.Common.Exceptions;
using SFC.Request.Application.Common.Extensions;
using SFC.Request.Application.Interfaces.Persistence.Repository.Game.General;
using SFC.Request.Application.Interfaces.Persistence.Repository.Game.Team;
using SFC.Request.Application.Interfaces.Persistence.Repository.Request.Game.Team;
using SFC.Request.Application.Interfaces.Persistence.Repository.Team.General;

namespace SFC.Request.Application.Features.Request.Game.Team.Commands.Create;
public class CreateGameTeamRequestCommandValidator : AbstractValidator<CreateGameTeamRequestCommand>
{
    private readonly IGameRepository _gameRepository;
    private readonly ITeamRepository _teamRepository;
    private readonly IGameTeamRequestRepository _gameTeamRequestRepository;
    private readonly IGameTeamRepository _gameTeamRepository;

    public CreateGameTeamRequestCommandValidator(
        IGameRepository gameRepository,
        ITeamRepository teamRepository,
        IGameTeamRequestRepository gameTeamRequestRepository,
        IGameTeamRepository gameTeamRepository)
    {
        _gameRepository = gameRepository;
        _teamRepository = teamRepository;
        _gameTeamRequestRepository = gameTeamRequestRepository;
        _gameTeamRepository = gameTeamRepository;

        SetRulesForRequest();
    }

    private void SetRulesForRequest()
    {
        RuleFor(p => p.Request.TeamComment)
           .RequiredProperty(ValidationConstants.DescriptionValueMaxLength, "Comment")
           .OverridePropertyName("Request.Comment");

        RuleFor(request => request.Request)
            // Game not found
            .MustAsync(async (request, cancellation) => await _gameRepository.AnyAsync(request.GameId).ConfigureAwait(true))
            .WithException(new NotFoundException(Localization.GameNotFound))
            // Team not found
            .MustAsync(async (request, cancellation) => await _teamRepository.AnyAsync(request.TeamId).ConfigureAwait(true))
            .WithException(new NotFoundException(Localization.TeamNotFound))
            // Team already in Game
            .MustAsync(async (request, cancellation) => !await _gameTeamRepository
                .AnyAsync(request.GameId, request.TeamId).ConfigureAwait(false))
            .WithException(new ConflictException(Localization.TeamAlreadyInGame))
            // request already exist
            .MustAsync(async (request, cancellation) => !await _gameTeamRequestRepository
                .AnyAsync(request.GameId, request.TeamId, RequestStatusEnum.Actual).ConfigureAwait(false))
            .WithException(new ConflictException(Localization.GameTeamRequestActiveAlreadyExist));
    }
}