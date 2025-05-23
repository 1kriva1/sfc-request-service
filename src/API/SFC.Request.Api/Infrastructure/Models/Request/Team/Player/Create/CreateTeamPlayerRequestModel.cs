using AutoMapper;

using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Application.Features.Request.Team.Player.Commands.Create;

namespace SFC.Request.Api.Infrastructure.Models.Request.Team.Player.Create;

/// <summary>
/// **Create** team player request model.
/// </summary>
public class CreateTeamPlayerRequestModel : IMapTo<CreateTeamPlayerRequestDto>
{
    /// <summary>
    /// Comment from player to team for invitation.
    /// </summary>
    public string Comment { get; set; } = default!;

    public void Mapping(Profile profile) => profile.CreateMap<CreateTeamPlayerRequestModel, CreateTeamPlayerRequestDto>()
                                                   .ForMember(p => p.PlayerComment, d => d.MapFrom(z => z.Comment));
}