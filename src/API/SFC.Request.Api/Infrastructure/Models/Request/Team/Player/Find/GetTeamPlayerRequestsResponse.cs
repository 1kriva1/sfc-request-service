using AutoMapper;

using SFC.Request.Api.Infrastructure.Models.Base;
using SFC.Request.Api.Infrastructure.Models.Request.Team.Player.Common;
using SFC.Request.Application.Common.Extensions;
using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Application.Features.Request.Team.Player.Queries.Find;

namespace SFC.Request.Api.Infrastructure.Models.Request.Team.Player.Find;

/// <summary>
/// **Get** team player requests response.
/// </summary>
public class GetTeamPlayerRequestsResponse : BaseListResponse<TeamPlayerRequestModel>, IMapFrom<GetTeamPlayerRequestsViewModel>
{
    public void Mapping(Profile profile) => profile.CreateMap<GetTeamPlayerRequestsViewModel, GetTeamPlayerRequestsResponse>()
                                                   .IgnoreAllNonExisting();
}