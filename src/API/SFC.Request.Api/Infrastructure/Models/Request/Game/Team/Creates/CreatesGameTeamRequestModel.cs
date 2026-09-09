using AutoMapper;

using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Application.Features.Request.Game.Team.Commands.Creates;

namespace SFC.Request.Api.Infrastructure.Models.Request.Game.Team.Creates;

/// <summary>
/// **Creates** Game Team Request model.
/// </summary>
public class CreatesGameTeamRequestModel : IMapTo<CreatesGameTeamRequestDto>
{
    /// <summary>
    /// Team for which Game send Request.
    /// </summary>
    public long Team { get; set; }

    /// <summary>
    /// Comment from Game to Team for invitation.
    /// </summary>
    public string Comment { get; set; } = default!;

    public void Mapping(Profile profile) => profile.CreateMap<CreatesGameTeamRequestModel, CreatesGameTeamRequestDto>()
                                                   .ForMember(p => p.TeamComment, d => d.MapFrom(z => z.Comment))
                                                   .ForMember(p => p.TeamId, d => d.MapFrom(z => z.Team));
}