using AutoMapper;

using SFC.Request.Api.Infrastructure.Models.Base;
using SFC.Request.Api.Infrastructure.Models.Request.Team.Player.Common;
using SFC.Request.Application.Common.Extensions;
using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Application.Features.Request.Team.Player.Queries.GetAll;

namespace SFC.Request.Api.Infrastructure.Models.Request.Team.Player.GetAll;

/// <summary>
/// **Get** all team player invites response.
/// </summary>
public class GetAllTeamPlayerRequestsResponse :
    BaseErrorResponse, IMapFrom<GetAllTeamPlayerRequestsViewModel>
{
    /// <summary>
    /// Team player request models.
    /// </summary>
    public IEnumerable<TeamPlayerRequestModel> Requests { get; set; } = null!;

    public void Mapping(Profile profile) => profile.CreateMap<GetAllTeamPlayerRequestsViewModel, GetAllTeamPlayerRequestsResponse>()
                                                   .IgnoreAllNonExisting();
}