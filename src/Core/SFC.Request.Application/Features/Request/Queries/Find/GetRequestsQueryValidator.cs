using FluentValidation;

using SFC.Request.Application.Features.Common.Validators.Common;
using SFC.Request.Application.Features.Request.Queries.Find.Dto.Filters;

namespace SFC.Request.Application.Features.Request.Queries.Find;
public class GetRequestsQueryValidator : AbstractValidator<GetRequestsQuery>
{
    public GetRequestsQueryValidator()
    {
        // pagination request validation
        RuleFor(command => command)
            .SetValidator(new PaginationRequestValidator<GetRequestsViewModel, GetRequestsFilterDto>());
    }
}