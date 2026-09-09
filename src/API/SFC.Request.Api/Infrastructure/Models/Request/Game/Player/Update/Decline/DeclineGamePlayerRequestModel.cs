using AutoMapper;

using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Application.Features.Request.Game.Player.Commands.Update;

namespace SFC.Request.Api.Infrastructure.Models.Request.Game.Player.Update.Decline;

/// <summary>
/// **Refuse** Game player Request model.
/// </summary>
public class DeclineGamePlayerRequestModel : IMapTo<UpdateGamePlayerRequestDto>
{
    /// <summary>
    /// Comment from player to explain why he/she is refuse Game Request.
    /// </summary>
    public string Comment { get; set; } = default!;

    public void Mapping(Profile profile) => profile.CreateMap<DeclineGamePlayerRequestModel, UpdateGamePlayerRequestDto>()
                                                   .ForMember(p => p.GameComment, d => d.MapFrom(z => z.Comment));
}