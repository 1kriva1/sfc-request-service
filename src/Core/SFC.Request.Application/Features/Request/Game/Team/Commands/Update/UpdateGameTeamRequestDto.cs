using AutoMapper;

using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Domain.Entities.Request.Game.Team;

namespace SFC.Request.Application.Features.Request.Game.Team.Commands.Update;
public class UpdateGameTeamRequestDto : IMapTo<GameTeamRequest>
{
    public long Id { get; set; }

    public long GameId { get; set; }

    public long TeamId { get; set; }

    public int Status { get; set; }

    public string? GameComment { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<UpdateGameTeamRequestDto, GameTeamRequest>()
                                                   .ForMember(dest => dest.GameComment, opt => opt.Condition(src => src.GameComment != null))
                                                   .ForMember(p => p.StatusId, d => d.MapFrom(z => z.Status));
}