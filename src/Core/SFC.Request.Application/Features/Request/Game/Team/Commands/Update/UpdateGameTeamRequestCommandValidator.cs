using FluentValidation;

using SFC.Request.Application.Common.Constants;
using SFC.Request.Application.Common.Exceptions;
using SFC.Request.Application.Common.Extensions;
using SFC.Request.Application.Interfaces.Persistence.Repository.Request.Game.Team;
using SFC.Request.Domain.Entities.Request.Game.Team;

namespace SFC.Request.Application.Features.Request.Game.Team.Commands.Update;
public class UpdateGameTeamRequestCommandValidator : AbstractValidator<UpdateGameTeamRequestCommand>
{
    private readonly IGameTeamRequestRepository _gameTeamRequestRepository;

    public UpdateGameTeamRequestCommandValidator(IGameTeamRequestRepository gameTeamRequestRepository)
    {
        _gameTeamRequestRepository = gameTeamRequestRepository;

        SetRulesForRequest();
    }

    private void SetRulesForRequest()
    {
        RuleFor(request => request.Request)
            .MustAsync((request, cancellation) => IsRequestHasActualStatusAsync(request))
            .WithException(new ConflictException(Localization.RequestAlreadyFinalized));

        When(p => p.Request.Status == (int)RequestStatusEnum.Declined, () =>
        {
            RuleFor(p => p.Request.GameComment!)
                .RequiredProperty(ValidationConstants.DescriptionValueMaxLength, "Comment")
                .OverridePropertyName("Request.Comment");
        });
    }

    private async Task<bool> IsRequestHasActualStatusAsync(UpdateGameTeamRequestDto Request)
    {
        GameTeamRequest? gameTeamRequest = await _gameTeamRequestRepository.GetByIdAsync(Request.Id).ConfigureAwait(true);
        return gameTeamRequest is null || gameTeamRequest.StatusId == (int)RequestStatusEnum.Actual;
    }
}