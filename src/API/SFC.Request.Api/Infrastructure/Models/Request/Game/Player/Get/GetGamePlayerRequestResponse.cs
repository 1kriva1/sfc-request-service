using AutoMapper;

using SFC.Request.Api.Infrastructure.Models.Base;
using SFC.Request.Api.Infrastructure.Models.Request.Game.Player.Common;
using SFC.Request.Application.Common.Extensions;
using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Application.Features.Request.Game.Player.Queries.Get;

#pragma warning disable CA1716
namespace SFC.Request.Api.Infrastructure.Models.Request.Game.Player.Get;
#pragma warning restore CA1716

/// <summary>
/// **Get** Game player Request response.
/// </summary>
public class GetGamePlayerRequestResponse :
    BaseErrorResponse, IMapFrom<GetGamePlayerRequestViewModel>
{
    /// <summary>
    /// Game player Request model.
    /// </summary>
    public GamePlayerRequestModel Request { get; set; } = null!;

    public void Mapping(Profile profile) => profile.CreateMap<GetGamePlayerRequestViewModel, GetGamePlayerRequestResponse>()
                                                   .IgnoreAllNonExisting();
}