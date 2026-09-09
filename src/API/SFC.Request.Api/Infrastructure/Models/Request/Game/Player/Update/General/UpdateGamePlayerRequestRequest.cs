using AutoMapper;

using SFC.Request.Application.Common.Extensions;
using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Application.Features.Request.Game.Player.Commands.Update;

namespace SFC.Request.Api.Infrastructure.Models.Request.Game.Player.Update.General;

/// <summary>
/// **Update** Game player Request request.
/// </summary>
public class UpdateGamePlayerRequestRequest : IMapTo<UpdateGamePlayerRequestCommand>
{
    /// <summary>
    /// Update Game player Request model.
    /// </summary>
    public UpdateGamePlayerRequestModel Request { get; set; } = default!;

    public void Mapping(Profile profile) => profile.CreateMap<UpdateGamePlayerRequestRequest, UpdateGamePlayerRequestCommand>()
                                                   .IgnoreAllNonExisting();
}