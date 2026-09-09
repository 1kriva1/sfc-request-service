using AutoMapper;

using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Application.Features.Request.Game.Player.Commands.Creates;

namespace SFC.Request.Api.Infrastructure.Models.Request.Game.Player.Creates;

/// <summary>
/// **Creates** Game player Request model.
/// </summary>
public class CreatesGamePlayerRequestModel : IMapTo<CreatesGamePlayerRequestDto>
{
    /// <summary>
    /// Player for which Game send Request.
    /// </summary>
    public long Player { get; set; }

    /// <summary>
    /// Comment from Game to player for invitation.
    /// </summary>
    public string Comment { get; set; } = default!;

    public void Mapping(Profile profile) => profile.CreateMap<CreatesGamePlayerRequestModel, CreatesGamePlayerRequestDto>()
                                                   .ForMember(p => p.PlayerComment, d => d.MapFrom(z => z.Comment))
                                                   .ForMember(p => p.PlayerId, d => d.MapFrom(z => z.Player));
}