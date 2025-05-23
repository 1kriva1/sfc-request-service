using FluentValidation;

using SFC.Request.Application.Common.Constants;
using SFC.Request.Application.Common.Exceptions;
using SFC.Request.Application.Common.Extensions;
using SFC.Request.Application.Interfaces.Persistence.Repository.Request.Team.Player;
using SFC.Request.Domain.Entities.Request.Team.Player;

namespace SFC.Request.Application.Features.Request.Team.Player.Commands.Update;
public class UpdateTeamPlayerRequestCommandValidator : AbstractValidator<UpdateTeamPlayerRequestCommand>
{
    private readonly ITeamPlayerRequestRepository _teamPlayerRequestRepository;

    public UpdateTeamPlayerRequestCommandValidator(ITeamPlayerRequestRepository teamPlayerRequestRepository)
    {
        _teamPlayerRequestRepository = teamPlayerRequestRepository;

        SetRulesForRequest();
    }

    private void SetRulesForRequest()
    {
        RuleFor(request => request.Request)
            .MustAsync((request, cancellation) => IsRequestHasActualStatusAsync(request))
            .WithException(new ConflictException(Localization.RequestAlreadyFinalized));

        When(p => p.Request.Status == (int)RequestStatusEnum.Declined, () =>
        {
            RuleFor(p => p.Request.TeamComment!)
                .RequiredProperty(ValidationConstants.DescriptionValueMaxLength, "Comment")
                .OverridePropertyName("Request.Comment");
        });
    }

    private async Task<bool> IsRequestHasActualStatusAsync(UpdateTeamPlayerRequestDto request)
    {
        TeamPlayerRequest? teamPlayerRequest = await _teamPlayerRequestRepository.GetByIdAsync(request.Id).ConfigureAwait(true);
        return teamPlayerRequest is null || teamPlayerRequest.StatusId == (int)RequestStatusEnum.Actual;
    }
}