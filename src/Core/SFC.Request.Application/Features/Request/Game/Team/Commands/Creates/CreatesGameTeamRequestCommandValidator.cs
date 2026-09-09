using FluentValidation;

using SFC.Request.Application.Common.Constants;
using SFC.Request.Application.Common.Extensions;
using SFC.Request.Application.Interfaces.Persistence.Repository.Game.General;
using SFC.Request.Application.Interfaces.Persistence.Repository.Game.Team;
using SFC.Request.Application.Interfaces.Persistence.Repository.Request.Game.Team;
using SFC.Request.Application.Interfaces.Persistence.Repository.Team.General;

namespace SFC.Request.Application.Features.Request.Game.Team.Commands.Creates;
public class CreatesGameTeamRequestCommandValidator : AbstractValidator<CreatesGameTeamRequestCommand>
{
    private readonly IGameRepository _gameRepository;
    private readonly ITeamRepository _teamRepository;
    private readonly IGameTeamRequestRepository _gameTeamRequestRepository;
    private readonly IGameTeamRepository _gameTeamRepository;

    public CreatesGameTeamRequestCommandValidator(
        IGameRepository gameRepository,
        ITeamRepository teamRepository,
        IGameTeamRequestRepository gameTeamRequestRepository,
        IGameTeamRepository gameTeamRepository)
    {
        _gameRepository = gameRepository;
        _teamRepository = teamRepository;
        _gameTeamRequestRepository = gameTeamRequestRepository;
        _gameTeamRepository = gameTeamRepository;

        RuleForEach(p => p.Requests)
           .SetValidator(new GameTeamRequestValidator(
               _gameRepository, _teamRepository,
               _gameTeamRequestRepository, _gameTeamRepository));
    }
}

public class GameTeamRequestValidator : AbstractValidator<CreatesGameTeamRequestDto>
{
    private readonly IGameRepository _gameRepository;
    private readonly ITeamRepository _teamRepository;
    private readonly IGameTeamRequestRepository _gameTeamRequestRepository;
    private readonly IGameTeamRepository _gameTeamRepository;

    public GameTeamRequestValidator(
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
        RuleFor(p => p.TeamComment)
           .RequiredProperty(ValidationConstants.DescriptionValueMaxLength, "Comment")
           .OverridePropertyName("Comment");

        RuleFor(request => request)
            // Game not found
            .MustAsync(async (request, cancellation) => await _gameRepository.AnyAsync(request.GameId).ConfigureAwait(true))
            .WithMessage(Localization.GameNotFound)
            // Team not found
            .MustAsync(async (request, cancellation) => await _teamRepository.AnyAsync(request.TeamId).ConfigureAwait(true))
            .WithMessage(Localization.TeamNotFound)
            // Team already in Game
            .MustAsync(async (request, cancellation) => !await _gameTeamRepository
            .AnyAsync(request.GameId, request.TeamId).ConfigureAwait(false))
            .WithMessage(Localization.TeamAlreadyInGame)
            // Request already exist
            .MustAsync(async (request, cancellation) => !await _gameTeamRequestRepository
            .AnyAsync(request.GameId, request.TeamId, RequestStatusEnum.Actual).ConfigureAwait(false))
            .WithMessage(Localization.GameTeamRequestActiveAlreadyExist);
    }
}