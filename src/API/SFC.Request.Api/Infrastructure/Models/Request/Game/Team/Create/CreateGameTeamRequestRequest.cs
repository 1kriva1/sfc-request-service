using AutoMapper;

using SFC.Request.Application.Common.Extensions;
using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Application.Features.Request.Game.Team.Commands.Create;

namespace SFC.Request.Api.Infrastructure.Models.Request.Game.Team.Create;

/// <summary>
/// **Create** Game Team Request request.
/// </summary>
public class CreateGameTeamRequestRequest : IMapTo<CreateGameTeamRequestCommand>
{
    /// <summary>
    /// Game Team Request model.
    /// </summary>
    public required CreateGameTeamRequestModel Request { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<CreateGameTeamRequestRequest, CreateGameTeamRequestCommand>()
                                                   .IgnoreAllNonExisting();
}