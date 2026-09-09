using AutoMapper;

using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Application.Features.Request.Game.Team.Commands.Update;

namespace SFC.Request.Api.Infrastructure.Models.Request.Game.Team.Update.Decline;

/// <summary>
/// **Refuse** Game Team Request model.
/// </summary>
public class DeclineGameTeamRequestModel : IMapTo<UpdateGameTeamRequestDto>
{
    /// <summary>
    /// Comment from Team to explain why he/she is refuse Game Request.
    /// </summary>
    public string Comment { get; set; } = default!;

    public void Mapping(Profile profile) => profile.CreateMap<DeclineGameTeamRequestModel, UpdateGameTeamRequestDto>()
                                                   .ForMember(p => p.GameComment, d => d.MapFrom(z => z.Comment));
}