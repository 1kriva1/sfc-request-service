using AutoMapper;

using SFC.Request.Application.Common.Extensions;
using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Application.Features.Request.Team.Player.Commands.Create;

namespace SFC.Request.Api.Infrastructure.Models.Request.Team.Player.Create;

/// <summary>
/// **Create** Request request.
/// </summary>
public class CreateTeamPlayerRequestRequest : IMapTo<CreateTeamPlayerRequestCommand>
{
    /// <summary>
    /// Team player request model.
    /// </summary>
    public CreateTeamPlayerRequestModel Request { get; set; } = null!;

    public void Mapping(Profile profile) => profile.CreateMap<CreateTeamPlayerRequestRequest, CreateTeamPlayerRequestCommand>()
                                                   .IgnoreAllNonExisting();
}