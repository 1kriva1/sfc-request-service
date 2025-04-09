using AutoMapper;

using SFC.Request.Api.Infrastructure.Models.Base;
using SFC.Request.Api.Infrastructure.Models.Request.Find.Filters;
using SFC.Request.Application.Common.Extensions;
using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Application.Features.Request.Queries.Find;

namespace SFC.Request.Api.Infrastructure.Models.Request.Find;

/// <summary>
/// **Get** requests request.
/// </summary>
public class GetRequestsRequest : BasePaginationRequest<GetRequestsFilterModel>, IMapTo<GetRequestsQuery>
{
    public void Mapping(Profile profile) => profile.CreateMap<GetRequestsRequest, GetRequestsQuery>()
                                                   .IgnoreAllNonExisting();
}