using AutoMapper;

using SFC.Request.Api.Infrastructure.Models.Base;
using SFC.Request.Api.Infrastructure.Models.Request.Team.Player.Find.Filters;
using SFC.Request.Application.Common.Extensions;
using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Application.Features.Request.Team.Player.Queries.Find;

namespace SFC.Request.Api.Infrastructure.Models.Request.Team.Player.Find;

/// <summary>
/// **Get** team player requests request.
/// </summary>
public class GetTeamPlayerRequestsRequest : BasePaginationRequest<GetTeamPlayerRequestsFilterModel>, IMapTo<GetTeamPlayerRequestsQuery>
{
    public void Mapping(Profile profile) => profile.CreateMap<GetTeamPlayerRequestsRequest, GetTeamPlayerRequestsQuery>()
                                                   .IgnoreAllNonExisting();
}