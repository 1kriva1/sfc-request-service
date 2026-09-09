using AutoMapper;

using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Application.Features.Request.Game.Player.Commands.Create;

namespace SFC.Request.Api.Infrastructure.Models.Request.Game.Player.Create;

/// <summary>
/// **Create** Game player Request model.
/// </summary>
public class CreateGamePlayerRequestModel : IMapTo<CreateGamePlayerRequestDto>
{
    /// <summary>
    /// Comment from Game to player for invitation.
    /// </summary>
    public string Comment { get; set; } = default!;

    public void Mapping(Profile profile) => profile.CreateMap<CreateGamePlayerRequestModel, CreateGamePlayerRequestDto>()
                                                   .ForMember(p => p.PlayerComment, d => d.MapFrom(z => z.Comment));
}