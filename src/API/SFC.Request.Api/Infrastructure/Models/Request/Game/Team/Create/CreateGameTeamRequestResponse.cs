using AutoMapper;

using SFC.Request.Api.Infrastructure.Models.Base;
using SFC.Request.Api.Infrastructure.Models.Request.Game.Team.Common;
using SFC.Request.Application.Common.Extensions;
using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Application.Features.Request.Game.Team.Commands.Create;

namespace SFC.Request.Api.Infrastructure.Models.Request.Game.Team.Create;

/// <summary>
/// **Create** Game Team Request response.
/// </summary>
public class CreateGameTeamRequestResponse :
    BaseErrorResponse, IMapFrom<CreateGameTeamRequestViewModel>
{
    /// <summary>
    /// Game Team Request model.
    /// </summary>
    public GameTeamRequestModel Request { get; set; } = null!;

    public void Mapping(Profile profile) => profile.CreateMap<CreateGameTeamRequestViewModel, CreateGameTeamRequestResponse>()
                                                   .IgnoreAllNonExisting();
}