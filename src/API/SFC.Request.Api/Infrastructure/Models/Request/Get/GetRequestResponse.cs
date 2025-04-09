using AutoMapper;

using SFC.Request.Api.Infrastructure.Models.Base;
using SFC.Request.Api.Infrastructure.Models.Request.Common;
using SFC.Request.Application.Common.Extensions;
using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Application.Features.Request.Queries.Get;

#pragma warning disable CA1716
namespace SFC.Request.Api.Infrastructure.Models.Request.Get;
#pragma warning restore CA1716

/// <summary>
/// **Get** request response.
/// </summary>
public class GetRequestResponse :
    BaseErrorResponse, IMapFrom<GetRequestViewModel>
{
    /// <summary>
    /// Request model.
    /// </summary>
    public RequestModel Request { get; set; } = null!;

    public void Mapping(Profile profile) => profile.CreateMap<GetRequestViewModel, GetRequestResponse>()
                                                   .IgnoreAllNonExisting();
}