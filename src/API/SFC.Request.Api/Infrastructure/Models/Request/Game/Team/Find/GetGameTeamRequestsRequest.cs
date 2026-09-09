using AutoMapper;

using SFC.Request.Api.Infrastructure.Models.Base;
using SFC.Request.Api.Infrastructure.Models.Request.Game.Team.Find.Filters;
using SFC.Request.Application.Common.Extensions;
using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Application.Features.Request.Game.Team.Queries.Find;

namespace SFC.Request.Api.Infrastructure.Models.Request.Game.Team.Find;

/// <summary>
/// **Get** Game Team Requests request.
/// </summary>
public class GetGameTeamRequestsRequest : BasePaginationRequest<GetGameTeamRequestsFilterModel>, IMapTo<GetGameTeamRequestsQuery>
{
    public void Mapping(Profile profile) => profile.CreateMap<GetGameTeamRequestsRequest, GetGameTeamRequestsQuery>()
                                                   .IgnoreAllNonExisting();
}