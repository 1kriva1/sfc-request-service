using AutoMapper;

using SFC.Request.Api.Infrastructure.Models.Base;
using SFC.Request.Api.Infrastructure.Models.Request.Game.Player.Common;
using SFC.Request.Application.Common.Extensions;
using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Application.Features.Request.Game.Player.Queries.Gets;

namespace SFC.Request.Api.Infrastructure.Models.Request.Game.Player.Gets;

/// <summary>
/// **Get** all Game player Requests response.
/// </summary>
public class GetsGamePlayerRequestResponse :
    BaseErrorResponse, IMapFrom<GetsGamePlayerRequestViewModel>
{
    /// <summary>
    /// Game player Request models.
    /// </summary>
    public IEnumerable<GamePlayerRequestModel> Requests { get; set; } = null!;

    public void Mapping(Profile profile) => profile.CreateMap<GetsGamePlayerRequestViewModel, GetsGamePlayerRequestResponse>()
                                                   .IgnoreAllNonExisting();
}