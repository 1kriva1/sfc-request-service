using AutoMapper;

using SFC.Request.Api.Infrastructure.Models.Base;
using SFC.Request.Api.Infrastructure.Models.Request.Game.Team.Common;
using SFC.Request.Application.Common.Extensions;
using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Application.Features.Request.Game.Team.Commands.Creates;

namespace SFC.Request.Api.Infrastructure.Models.Request.Game.Team.Creates;

/// <summary>
/// **Create** Game Team Request response.
/// </summary>
public class CreatesGameTeamRequestResponse :
    BaseErrorResponse, IMapFrom<CreatesGameTeamRequestViewModel>
{
    /// <summary>
    /// Game Team Request models.
    /// </summary>
    public IEnumerable<GameTeamRequestModel> Requests { get; set; } = null!;

    public void Mapping(Profile profile) => profile.CreateMap<CreatesGameTeamRequestViewModel, CreatesGameTeamRequestResponse>()
                                                   .IgnoreAllNonExisting();
}