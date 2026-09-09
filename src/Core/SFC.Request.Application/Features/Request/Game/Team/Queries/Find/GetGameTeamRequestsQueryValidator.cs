using FluentValidation;

using SFC.Request.Application.Features.Common.Validators.Common;
using SFC.Request.Application.Features.Common.Validators.Team;
using SFC.Request.Application.Features.Request.Game.Team.Queries.Find.Dto.Filters;

namespace SFC.Request.Application.Features.Request.Game.Team.Queries.Find;
public class GetGameTeamRequestsQueryValidator : AbstractValidator<GetGameTeamRequestsQuery>
{
    public GetGameTeamRequestsQueryValidator()
    {
        // pagination request filter
        RuleFor(command => command)
            .SetValidator(new PaginationRequestValidator<GetGameTeamRequestsViewModel, GetGameTeamRequestsFilterDto>());

        // Team filter
        When(p => p?.Filter?.Team != null, () =>
        {
            RuleFor(command => command.Filter.Team!)
                .SetValidator(new TeamFilterValidator());
        });
    }
}