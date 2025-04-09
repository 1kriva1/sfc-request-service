using SFC.Request.Application.Features.Common.Models.Find.Filters;
using SFC.Request.Application.Features.Request.Queries.Find.Dto.Filters;

namespace SFC.Request.Application.Features.Request.Queries.Find.Extensions;
public static class GetRequestsFiltersExtensions
{
    public static IEnumerable<Filter<RequestEntity>> BuildSearchFilters(this GetRequestsFilterDto filter)
    {
        return [];
    }
}