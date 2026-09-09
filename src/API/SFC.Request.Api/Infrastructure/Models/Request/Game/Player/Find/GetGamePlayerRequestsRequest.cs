using AutoMapper;

using SFC.Request.Api.Infrastructure.Models.Base;
using SFC.Request.Api.Infrastructure.Models.Request.Game.Player.Find.Filters;
using SFC.Request.Application.Common.Extensions;
using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Application.Features.Request.Game.Player.Queries.Find;

namespace SFC.Request.Api.Infrastructure.Models.Request.Game.Player.Find;

/// <summary>
/// **Get** Game player Requests request.
/// </summary>
public class GetGamePlayerRequestsRequest : BasePaginationRequest<GetGamePlayerRequestsFilterModel>, IMapTo<GetGamePlayerRequestsQuery>
{
    public void Mapping(Profile profile) => profile.CreateMap<GetGamePlayerRequestsRequest, GetGamePlayerRequestsQuery>()
                                                   .IgnoreAllNonExisting();
}