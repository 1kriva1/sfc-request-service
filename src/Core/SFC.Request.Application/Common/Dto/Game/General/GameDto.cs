using AutoMapper;

using SFC.Request.Application.Common.Dto.Common;
using SFC.Request.Application.Common.Dto.Game.Player;
using SFC.Request.Application.Common.Mappings.Interfaces;

namespace SFC.Request.Application.Common.Dto.Game.General;
public class GameDto : AuditableDto, IMapFromReverse<GameEntity>
{
    public long Id { get; set; }

    public Guid UserId { get; set; }

    public int StatusId { get; set; }

    public GameProfileDto Profile { get; set; } = null!;

    public IEnumerable<GamePlayerDto> Players { get; set; } = [];

    public void Mapping(Profile profile)
    {
        profile.CreateMap<GameDto, GameEntity>()
                .ForMember(p => p.GeneralProfile, d => d.MapFrom(z => z.Profile.General))
                .ForMember(p => p.FinancialProfile, d => d.MapFrom(z => z.Profile.Financial))
                .ForMember(p => p.InventaryProfile, d => d.MapFrom(z => z.Profile.Inventary))
                .ForMember(p => p.Availability, d => d.MapFrom(z => z.Profile.General.Availability))
                .ForMember(p => p.Tags, d => d.MapFrom(z => z.Profile.General.Tags))
                .ForMember(p => p.DomainEvents, d => d.Ignore())
                .ReverseMap();
    }
}