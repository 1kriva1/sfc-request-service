using AutoMapper;

using SFC.Request.Api.Infrastructure.Models.Base;
using SFC.Request.Api.Infrastructure.Models.Request.Common;
using SFC.Request.Application.Common.Extensions;
using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Application.Features.Request.Queries.Find;

namespace SFC.Request.Api.Infrastructure.Models.Request.Find;

/// <summary>
/// **Get** requests response.
/// </summary>
public class GetRequestsResponse : BaseListResponse<RequestModel>, IMapFrom<GetRequestsViewModel>
{
    public void Mapping(Profile profile) => profile.CreateMap<GetRequestsViewModel, GetRequestsResponse>()
                                                   .IgnoreAllNonExisting();
}