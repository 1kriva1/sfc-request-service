using AutoMapper;

using SFC.Request.Application.Common.Extensions;
using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Application.Features.Request.Game.Team.Commands.Update;

namespace SFC.Request.Api.Infrastructure.Models.Request.Game.Team.Update.General;

/// <summary>
/// **Update** Game Team Request request.
/// </summary>
public class UpdateGameTeamRequestRequest : IMapTo<UpdateGameTeamRequestCommand>
{
    /// <summary>
    /// Update Game Team Request model.
    /// </summary>
    public UpdateGameTeamRequestModel Request { get; set; } = default!;

    public void Mapping(Profile profile) => profile.CreateMap<UpdateGameTeamRequestRequest, UpdateGameTeamRequestCommand>()
                                                   .IgnoreAllNonExisting();
}