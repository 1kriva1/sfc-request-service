using AutoMapper;

using SFC.Request.Api.Infrastructure.Models.Base;
using SFC.Request.Api.Infrastructure.Models.Request.Team.Player.Common;
using SFC.Request.Application.Common.Extensions;
using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Application.Features.Request.Team.Player.Queries.Get;

namespace SFC.Request.Api.Infrastructure.Models.Request.Team.Player.Get;

/// <summary>
/// **Get** request response.
/// </summary>
public class GetTeamPlayerRequestResponse :
    BaseErrorResponse, IMapFrom<GetTeamPlayerRequestViewModel>
{
    /// <summary>
    /// Team player request model.
    /// </summary>
    public TeamPlayerRequestModel Request { get; set; } = null!;

    public void Mapping(Profile profile) => profile.CreateMap<GetTeamPlayerRequestViewModel, GetTeamPlayerRequestResponse>()
                                                   .IgnoreAllNonExisting();
}