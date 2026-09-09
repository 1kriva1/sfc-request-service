using AutoMapper;

using SFC.Request.Api.Infrastructure.Models.Base;
using SFC.Request.Api.Infrastructure.Models.Request.Game.Player.Common;
using SFC.Request.Application.Common.Extensions;
using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Application.Features.Request.Game.Player.Queries.Find;

namespace SFC.Request.Api.Infrastructure.Models.Request.Game.Player.Find;

/// <summary>
/// **Get** Game player Requests response.
/// </summary>
public class GetGamePlayerRequestsResponse : BaseListResponse<GamePlayerRequestModel>, IMapFrom<GetGamePlayerRequestsViewModel>
{
    public void Mapping(Profile profile) => profile.CreateMap<GetGamePlayerRequestsViewModel, GetGamePlayerRequestsResponse>()
                                                   .IgnoreAllNonExisting();
}