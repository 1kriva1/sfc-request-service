using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Application.Features.Request.Data.Queries.Common.Dto;

namespace SFC.Request.Api.Infrastructure.Models.Request.Data.Common;

/// <summary>
/// Data value.
/// </summary>
public class DataValueModel : IMapFrom<DataValueDto>
{
    /// <summary>
    /// Unique identificator of data type.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Describe data type.
    /// </summary>
    public required string Title { get; set; }
}