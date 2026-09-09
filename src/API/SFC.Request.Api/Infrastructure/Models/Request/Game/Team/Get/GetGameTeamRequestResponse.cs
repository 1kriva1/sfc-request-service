using AutoMapper;

using SFC.Request.Api.Infrastructure.Models.Base;
using SFC.Request.Api.Infrastructure.Models.Request.Game.Team.Common;
using SFC.Request.Application.Common.Extensions;
using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Application.Features.Request.Game.Team.Queries.Get;

#pragma warning disable CA1716
namespace SFC.Request.Api.Infrastructure.Models.Request.Game.Team.Get;
#pragma warning restore CA1716

/// <summary>
/// **Get** Game Team Request response.
/// </summary>
public class GetGameTeamRequestResponse :
    BaseErrorResponse, IMapFrom<GetGameTeamRequestViewModel>
{
    /// <summary>
    /// Game Team Request model.
    /// </summary>
    public GameTeamRequestModel Request { get; set; } = null!;

    public void Mapping(Profile profile) => profile.CreateMap<GetGameTeamRequestViewModel, GetGameTeamRequestResponse>()
                                                   .IgnoreAllNonExisting();
}