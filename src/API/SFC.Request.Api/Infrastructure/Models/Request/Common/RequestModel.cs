using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Application.Features.Request.Common.Dto;

namespace SFC.Request.Api.Infrastructure.Models.Request.Common;

/// <summary>
/// Request model.
/// </summary>
public class RequestModel : IMapFrom<RequestDto>
{
    /// <summary>
    /// Unique identifier.
    /// </summary>
    public long Id { get; set; }
}