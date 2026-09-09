using AutoMapper;

using SFC.Request.Application.Common.Extensions;
using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Application.Features.Request.Game.Player.Commands.Creates;

namespace SFC.Request.Api.Infrastructure.Models.Request.Game.Player.Creates;

/// <summary>
/// **Creates** Game player Requests request.
/// </summary>
public class CreatesGamePlayerRequestRequest : IMapTo<CreatesGamePlayerRequestCommand>
{
    /// <summary>
    /// Game player Request model.
    /// </summary>
    public required IEnumerable<CreatesGamePlayerRequestModel> Requests { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<CreatesGamePlayerRequestRequest, CreatesGamePlayerRequestCommand>()
                                                   .IgnoreAllNonExisting();
}