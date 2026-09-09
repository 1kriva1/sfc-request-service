using AutoMapper;

using SFC.Request.Application.Common.Extensions;
using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Application.Features.Request.Game.Player.Commands.Create;

namespace SFC.Request.Api.Infrastructure.Models.Request.Game.Player.Create;

/// <summary>
/// **Create** Game player Request request.
/// </summary>
public class CreateGamePlayerRequestRequest : IMapTo<CreateGamePlayerRequestCommand>
{
    /// <summary>
    /// Game player Request model.
    /// </summary>
    public required CreateGamePlayerRequestModel Request { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<CreateGamePlayerRequestRequest, CreateGamePlayerRequestCommand>()
                                                   .IgnoreAllNonExisting();
}