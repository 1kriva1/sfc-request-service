using AutoMapper;

using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Application.Features.Request.Team.Player.Commands.Update;

namespace SFC.Request.Api.Infrastructure.Models.Request.Team.Player.Update.Decline;

/// <summary>
/// **Decline** team player request model.
/// </summary>
public class DeclineTeamPlayerRequestModel : IMapTo<UpdateTeamPlayerRequestDto>
{
    /// <summary>
    /// Comment from team to explain why player is declined to join team.
    /// </summary>
    public string Comment { get; set; } = default!;

    public void Mapping(Profile profile) => profile.CreateMap<DeclineTeamPlayerRequestModel, UpdateTeamPlayerRequestDto>()
                                                   .ForMember(p => p.TeamComment, d => d.MapFrom(z => z.Comment));
}