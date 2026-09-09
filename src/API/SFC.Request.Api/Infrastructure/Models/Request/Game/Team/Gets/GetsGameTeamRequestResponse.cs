using AutoMapper;

using SFC.Request.Api.Infrastructure.Models.Base;
using SFC.Request.Api.Infrastructure.Models.Request.Game.Team.Common;
using SFC.Request.Application.Common.Extensions;
using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Application.Features.Request.Game.Team.Queries.Gets;

namespace SFC.Request.Api.Infrastructure.Models.Request.Game.Team.Gets;

/// <summary>
/// **Get** all Game Team Requests response.
/// </summary>
public class GetsGameTeamRequestResponse :
    BaseErrorResponse, IMapFrom<GetsGameTeamRequestViewModel>
{
    /// <summary>
    /// Game Team Request models.
    /// </summary>
    public IEnumerable<GameTeamRequestModel> Requests { get; set; } = null!;

    public void Mapping(Profile profile) => profile.CreateMap<GetsGameTeamRequestViewModel, GetsGameTeamRequestResponse>()
                                                   .IgnoreAllNonExisting();
}