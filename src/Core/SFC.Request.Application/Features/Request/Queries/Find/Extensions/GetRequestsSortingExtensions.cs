using System.Linq.Expressions;

using SFC.Request.Application.Features.Common.Dto.Common;
using SFC.Request.Application.Features.Common.Extensions;
using SFC.Request.Application.Features.Common.Models.Find.Sorting;

namespace SFC.Request.Application.Features.Request.Queries.Find.Extensions;
public static class GetRequestsSortingExtensions
{
    public static IEnumerable<Sorting<RequestEntity, dynamic>> BuildRequestSearchSorting(this IEnumerable<SortingDto> sorting)
        => sorting.BuildSearchSorting<RequestEntity>(BuildExpression);

    private static Expression<Func<RequestEntity, dynamic>>? BuildExpression(string name)
    {
        return name switch
        {
            _ => null
        };
    }
}