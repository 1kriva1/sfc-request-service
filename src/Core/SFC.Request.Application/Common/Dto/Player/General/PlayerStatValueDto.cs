using AutoMapper;

using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Domain.Entities.Player;

namespace SFC.Request.Application.Common.Dto.Player.General;
public record PlayerStatValueDto : IMapFromReverse<PlayerStat>
{
    public int Type { get; set; }

    public byte Value { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<PlayerStatValueDto, PlayerStat>()
            .ForMember(p => p.DomainEvents, d => d.Ignore())
            .ForMember(p => p.Id, d => d.Ignore())
            .ForMember(p => p.Player, d => d.Ignore())
            .ForMember(p => p.TypeId, d => d.MapFrom(e => e.Type))
            .ForMember(p => p.Type, d => d.Ignore())
            .ReverseMap();
    }
}