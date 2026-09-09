using AutoMapper;

using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Application.Features.Request.Game.Team.Commands.Update;

namespace SFC.Request.Api.Infrastructure.Models.Request.Game.Team.Update.General;

/// <summary>
/// **Update** Game Team Request model.
/// </summary>
public class UpdateGameTeamRequestModel : IMapTo<UpdateGameTeamRequestDto>
{
    /// <summary>
    /// Comment from Game to Team for invitation.
    /// </summary>
    public string Comment { get; set; } = default!;

    public void Mapping(Profile profile) => profile.CreateMap<UpdateGameTeamRequestModel, UpdateGameTeamRequestDto>()
                                                   .ForMember(p => p.GameComment, d => d.MapFrom(z => z.Comment));
}