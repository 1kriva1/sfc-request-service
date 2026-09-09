using AutoMapper;

using SFC.Request.Application.Common.Extensions;
using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Application.Features.Request.Game.Player.Commands.Update;

namespace SFC.Request.Api.Infrastructure.Models.Request.Game.Player.Update.Decline;

/// <summary>
/// **Refuse** Game player Request request.
/// </summary>
public class DeclineGamePlayerRequestRequest : IMapTo<UpdateGamePlayerRequestCommand>
{
    /// <summary>
    /// Refuse Game player Request model.
    /// </summary>
    public DeclineGamePlayerRequestModel Request { get; set; } = default!;

    public void Mapping(Profile profile) => profile.CreateMap<DeclineGamePlayerRequestRequest, UpdateGamePlayerRequestCommand>()
                                                   .IgnoreAllNonExisting();
}