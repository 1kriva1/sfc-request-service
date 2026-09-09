using AutoMapper;

using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Application.Features.Request.Game.Team.Commands.Create;

namespace SFC.Request.Api.Infrastructure.Models.Request.Game.Team.Create;

/// <summary>
/// **Create** Game Team Request model.
/// </summary>
public class CreateGameTeamRequestModel : IMapTo<CreateGameTeamRequestDto>
{
    /// <summary>
    /// Comment from Game to Team for invitation.
    /// </summary>
    public string Comment { get; set; } = default!;

    public void Mapping(Profile profile) => profile.CreateMap<CreateGameTeamRequestModel, CreateGameTeamRequestDto>()
                                                   .ForMember(p => p.TeamComment, d => d.MapFrom(z => z.Comment));
}