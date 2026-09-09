using AutoMapper;

using SFC.Request.Api.Infrastructure.Models.Base;
using SFC.Request.Api.Infrastructure.Models.Request.Game.Player.Common;
using SFC.Request.Application.Common.Extensions;
using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Application.Features.Request.Game.Player.Commands.Creates;

namespace SFC.Request.Api.Infrastructure.Models.Request.Game.Player.Creates;

/// <summary>
/// **Create** Game player Request response.
/// </summary>
public class CreatesGamePlayerRequestResponse :
    BaseErrorResponse, IMapFrom<CreatesGamePlayerRequestViewModel>
{
    /// <summary>
    /// Game player Request models.
    /// </summary>
    public IEnumerable<GamePlayerRequestModel> Requests { get; set; } = null!;

    public void Mapping(Profile profile) => profile.CreateMap<CreatesGamePlayerRequestViewModel, CreatesGamePlayerRequestResponse>()
                                                   .IgnoreAllNonExisting();
}