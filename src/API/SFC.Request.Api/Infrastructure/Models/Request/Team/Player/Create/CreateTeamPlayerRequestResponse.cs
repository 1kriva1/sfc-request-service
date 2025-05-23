using AutoMapper;

using SFC.Request.Api.Infrastructure.Models.Base;
using SFC.Request.Api.Infrastructure.Models.Request.Team.Player.Common;
using SFC.Request.Application.Common.Extensions;
using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Application.Features.Request.Team.Player.Commands.Create;

namespace SFC.Request.Api.Infrastructure.Models.Request.Team.Player.Create;

/// <summary>
/// **Create** request response model.
/// </summary>
public class CreateTeamPlayerRequestResponse :
    BaseErrorResponse, IMapFrom<CreateTeamPlayerRequestViewModel>
{
    /// <summary>
    /// Team player request model.
    /// </summary>
    public TeamPlayerRequestModel Request { get; set; } = null!;

    public void Mapping(Profile profile) => profile.CreateMap<CreateTeamPlayerRequestViewModel, CreateTeamPlayerRequestResponse>()
                                                   .IgnoreAllNonExisting();
}