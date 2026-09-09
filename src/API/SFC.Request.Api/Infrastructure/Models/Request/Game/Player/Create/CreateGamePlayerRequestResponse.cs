using AutoMapper;

using SFC.Request.Api.Infrastructure.Models.Base;
using SFC.Request.Api.Infrastructure.Models.Request.Game.Player.Common;
using SFC.Request.Application.Common.Extensions;
using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Application.Features.Request.Game.Player.Commands.Create;

namespace SFC.Request.Api.Infrastructure.Models.Request.Game.Player.Create;

/// <summary>
/// **Create** Game player Request response.
/// </summary>
public class CreateGamePlayerRequestResponse :
    BaseErrorResponse, IMapFrom<CreateGamePlayerRequestViewModel>
{
    /// <summary>
    /// Game player Request model.
    /// </summary>
    public GamePlayerRequestModel Request { get; set; } = null!;

    public void Mapping(Profile profile) => profile.CreateMap<CreateGamePlayerRequestViewModel, CreateGamePlayerRequestResponse>()
                                                   .IgnoreAllNonExisting();
}