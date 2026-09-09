using AutoMapper;

using SFC.Request.Application.Common.Extensions;
using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Application.Features.Request.Game.Team.Commands.Creates;

namespace SFC.Request.Api.Infrastructure.Models.Request.Game.Team.Creates;

/// <summary>
/// **Creates** Game Team Requests request.
/// </summary>
public class CreatesGameTeamRequestRequest : IMapTo<CreatesGameTeamRequestCommand>
{
    /// <summary>
    /// Game Team Request model.
    /// </summary>
    public required IEnumerable<CreatesGameTeamRequestModel> Requests { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<CreatesGameTeamRequestRequest, CreatesGameTeamRequestCommand>()
                                                   .IgnoreAllNonExisting();
}