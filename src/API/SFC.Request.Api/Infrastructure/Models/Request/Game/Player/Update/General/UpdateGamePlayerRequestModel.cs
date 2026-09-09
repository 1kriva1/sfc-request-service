using AutoMapper;

using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Application.Features.Request.Game.Player.Commands.Update;

namespace SFC.Request.Api.Infrastructure.Models.Request.Game.Player.Update.General;

/// <summary>
/// **Update** Game player Request model.
/// </summary>
public class UpdateGamePlayerRequestModel : IMapTo<UpdateGamePlayerRequestDto>
{
    /// <summary>
    /// Comment from Game to player for invitation.
    /// </summary>
    public string Comment { get; set; } = default!;

    public void Mapping(Profile profile) => profile.CreateMap<UpdateGamePlayerRequestModel, UpdateGamePlayerRequestDto>()
                                                   .ForMember(p => p.GameComment, d => d.MapFrom(z => z.Comment));
}