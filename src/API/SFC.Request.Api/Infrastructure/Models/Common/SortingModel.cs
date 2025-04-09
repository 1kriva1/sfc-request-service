using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Application.Features.Common.Dto.Common;

namespace SFC.Request.Api.Infrastructure.Models.Common;

/// <summary>
/// **Sorting** model.
/// </summary>
public class SortingModel : IMapTo<SortingDto>
{
    /// <summary>
    /// **Name of property** by which sorting will be performed.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Sorting **direction** (ascending or descending).
    /// </summary>
    public required string Direction { get; set; }
}