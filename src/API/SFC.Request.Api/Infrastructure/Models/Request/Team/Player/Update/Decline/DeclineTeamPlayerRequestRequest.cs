using AutoMapper;

using SFC.Request.Application.Common.Extensions;
using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Application.Features.Request.Team.Player.Commands.Update;

namespace SFC.Request.Api.Infrastructure.Models.Request.Team.Player.Update.Decline;

/// <summary>
/// **Decline** team player request request.
/// </summary>
public class DeclineTeamPlayerRequestRequest : IMapTo<UpdateTeamPlayerRequestCommand>
{
    /// <summary>
    /// Decline team player request model.
    /// </summary>
    public DeclineTeamPlayerRequestModel Request { get; set; } = null!;

    public void Mapping(Profile profile) => profile.CreateMap<DeclineTeamPlayerRequestRequest, UpdateTeamPlayerRequestCommand>()
                                                   .IgnoreAllNonExisting();
}