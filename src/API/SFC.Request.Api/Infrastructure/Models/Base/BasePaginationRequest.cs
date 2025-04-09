using SFC.Request.Api.Infrastructure.Models.Common;
using SFC.Request.Api.Infrastructure.Models.Pagination;

namespace SFC.Request.Api.Infrastructure.Models.Base;

/// <summary>
/// **Base** pagination request.
/// </summary>
/// <typeparam name="T">Any type of filter model.</typeparam>
public class BasePaginationRequest<T> where T : class
{
    /// <summary>
    /// Pagination model.
    /// </summary>
    public required PaginationModel Pagination { get; set; }

    /// <summary>
    /// Sorting model.
    /// </summary>
    public IEnumerable<SortingModel>? Sorting { get; set; }

    /// <summary>
    /// Generic filter model.
    /// </summary>
    public T? Filter { get; set; }
}