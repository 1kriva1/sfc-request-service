using AutoMapper;

using SFC.Request.Application.Common.Extensions;
using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Application.Features.Request.Game.Team.Commands.Update;

namespace SFC.Request.Api.Infrastructure.Models.Request.Game.Team.Update.Decline;

/// <summary>
/// **Refuse** Game Team Request request.
/// </summary>
public class DeclineGameTeamRequestRequest : IMapTo<UpdateGameTeamRequestCommand>
{
    /// <summary>
    /// Refuse Game Team Request model.
    /// </summary>
    public DeclineGameTeamRequestModel Request { get; set; } = default!;

    public void Mapping(Profile profile) => profile.CreateMap<DeclineGameTeamRequestRequest, UpdateGameTeamRequestCommand>()
                                                   .IgnoreAllNonExisting();
}