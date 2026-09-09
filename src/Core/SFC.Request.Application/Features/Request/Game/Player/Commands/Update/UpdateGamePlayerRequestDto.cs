using AutoMapper;

using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Domain.Entities.Request.Game.Player;

namespace SFC.Request.Application.Features.Request.Game.Player.Commands.Update;
public class UpdateGamePlayerRequestDto : IMapTo<GamePlayerRequest>
{
    public long Id { get; set; }

    public long GameId { get; set; }

    public long PlayerId { get; set; }

    public int Status { get; set; }

    public string? GameComment { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<UpdateGamePlayerRequestDto, GamePlayerRequest>()
                                                   .ForMember(dest => dest.GameComment, opt => opt.Condition(src => src.GameComment != null))
                                                   .ForMember(p => p.StatusId, d => d.MapFrom(z => z.Status));
}